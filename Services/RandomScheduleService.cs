﻿using SportsScheduleProLibrary.Data;
using SportsScheduleProLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SportsScheduleProLibrary.Services
{
    public class RandomScheduleService
    {
        public static List<DayOfWeek> DayOfWeekPreference = new List<DayOfWeek>
        {
            DayOfWeek.Saturday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Sunday, DayOfWeek.Friday
        };

        public static List<Game> GameSchedule(League league = null, Season season = null, Club club = null)
        {

            SportsScheduleProDataContext dbc = new SportsScheduleProDataContext();
            List<Club> clubs = dbc.Clubs.Include(s => s.Leagues).ThenInclude(s => s.Fields).Include(s => s.Seasons).Include(s => s.Leagues).ThenInclude(s => s.Teams).ThenInclude(s => s.ExcludedGameDates).ToList();
            List<Game> games = dbc.Games.ToList();

            if (club != null)
                clubs = new List<Club> { club };

            foreach (Club c in clubs)
            {
                List<League> leagues = c.Leagues.ToList();
                if (league != null)
                    leagues = new List<League> { league };

                foreach(League l in leagues)
                {
                    List<Tuple<Field, DateTime>> possibleUnfilteredTimeSlots = new List<Tuple<Field, DateTime>>();

                    Random rng = new Random(Guid.NewGuid().GetHashCode() + Environment.TickCount);
                    List<Field> fieldsForLeague = l.Fields.OrderBy(_ => rng.Next()).ToList();
                    Season currentLeagueSeason = season ?? c.Seasons.OrderByDescending(s => s.EndDate).FirstOrDefault();
                    TimeZoneInfo tzi = TimeZoneInfo.Local;

                    //Generate list of possible times and places
                    if (l.StartDate == null || l.EndDate == null)
                        continue;
                    else
                    {
                        foreach (Field f in fieldsForLeague)
                        {
                            DateTime currentDate = (currentLeagueSeason.StartDate ?? DateTime.Now) >= DateTime.Now ? (currentLeagueSeason.StartDate ?? DateTime.Now) : DateTime.Now;
                            while (currentDate < l.EndDate)
                            {
                                if ((currentDate.DayOfWeek == DayOfWeek.Sunday && !f.IsOpenSunday) || (currentDate.DayOfWeek == DayOfWeek.Monday && !f.IsOpenMonday) || (currentDate.DayOfWeek == DayOfWeek.Tuesday && !f.IsOpenTuesday) || (currentDate.DayOfWeek == DayOfWeek.Wednesday && !f.IsOpenWednesday) || (currentDate.DayOfWeek == DayOfWeek.Thursday && !f.IsOpenThursday) || (currentDate.DayOfWeek == DayOfWeek.Friday && !f.IsOpenFriday) || (currentDate.DayOfWeek == DayOfWeek.Saturday && !f.IsOpenSaturday))
                                    continue;

                                if (currentDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    for (int x = 0; x < l.DailyGamesPerFieldSaturday; x++)
                                    {
                                        possibleUnfilteredTimeSlots.Add(new Tuple<Field, DateTime>(f, currentDate.AddHours(l.EarliestGameTimeHourSaturday).AddMinutes(l.EarliestGameTimeMinuteSaturday).AddMinutes(l.GameLengthWindow * x)));
                                    }
                                }
                                //else if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                                //{
                                //    for (int x = 0; x < l.DailyGamesPerFieldSunday; x++)
                                //    {
                                //        possibleUnfilteredTimeSlots.Add(new Tuple<Field, DateTime>(f, currentDate.AddHours(l.EarliestGameTimeHourSunday).AddMinutes(l.EarliestGameTimeMinuteSunday).AddMinutes(l.GameLengthWindow * x)));
                                //    }
                                //}
                                else if(tzi.IsDaylightSavingTime(currentDate))
                                {
                                    for (int x = 0; x < l.DailyGamesPerFieldWeekday; x++)
                                    {
                                        possibleUnfilteredTimeSlots.Add(new Tuple<Field, DateTime>(f, currentDate.AddHours(l.EarliestGameTimeHourWeekday).AddMinutes(l.EarliestGameTimeMinuteWeekday).AddMinutes(l.GameLengthWindow * x)));
                                    }
                                }
                                currentDate = currentDate.AddDays(1);
                            }
                        }

                    }


                    //Generate list of matchups excluding 
                    List<Team> teams = l.Teams.ToList().OrderByDescending(s => s.ExcludedGameDates.Count()).OrderBy(_ => rng.Next()).ToList();
                    List<int> teamIds = teams.Select(s => s.TeamId).ToList();
                    games = dbc.Games.Where(s => s.League.LeagueId == l.LeagueId).ToList();

                    // First, ensure all teams have an entry in the game count dictionary
                    List<Game> homeTeamGames = dbc.Games
                        .Where(s => teamIds.Contains(s.HomeTeamId))
                        .ToList();

                    List<Game> awayTeamGames = dbc.Games
                        .Where(s => teamIds.Contains(s.AwayTeamId))
                        .ToList();

                    Dictionary<int, int> teamGameCount = new Dictionary<int, int>();
                    foreach(Game g in homeTeamGames)
                    {
                        if (!teamGameCount.ContainsKey(g.HomeTeamId))
                            teamGameCount.Add(g.HomeTeamId, 1);
                        else
                            teamGameCount[g.HomeTeamId] += 1;
                    }

                    foreach (Game g in awayTeamGames)
                    {
                        if (!teamGameCount.ContainsKey(g.AwayTeamId))
                            teamGameCount.Add(g.AwayTeamId, 1);
                        else
                            teamGameCount[g.AwayTeamId] += 1;
                    }

                    // Ensure all teams have an entry (teams with 0 games)
                    foreach (var team in teams)
                    {
                        if (!teamGameCount.ContainsKey(team.TeamId))
                            teamGameCount[team.TeamId] = 0;
                    }

                    // Shuffle the teams once for fairness
                    var shuffledTeams = teams.OrderBy(_ => rng.Next()).ToList();

                    // Perform the round-robin scheduling
                    foreach (Team t in shuffledTeams)
                    {
                        for (int x = 0; x < l.GamesPerSeason; x++)
                        {
                            int id = teamGameCount.Where(s => s.Key != t.TeamId).OrderBy(s => s.Value).ThenBy(_ => rng.Next()).FirstOrDefault().Key;


                            // Ensure both teams are within the valid game range (either l.GamesPerSeason or l.GamesPerSeason + 1)
                            int teamCountHome = teamGameCount.ContainsKey(t.TeamId) ? teamGameCount[t.TeamId] : 0;
                            int teamCountAway = teamGameCount.ContainsKey(id) ? teamGameCount[id] : 0;

                            if (teamCountHome >= l.GamesPerSeason || teamCountAway >= l.GamesPerSeason)
                                continue;

                            // Add the game and update game counts
                            if (games.Where(s => s.HomeTeamId == t.TeamId && s.AwayTeamId == id).Count() < l.PlayEachTimeCount)
                            {
                                games.Add(new Game
                                {
                                    HomeTeamId = t.TeamId,
                                    AwayTeamId = id,
                                });

                                // Update team counts
                                teamGameCount[t.TeamId]++;
                                teamGameCount[id]++;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        //foreach (Team i in shuffledTeams)
                        //{
                        //    if (t == i)
                        //        continue;

                        //    // Check if these teams have already played the allowed number of times
                        //    //if (games.Count(s => (s.HomeTeamId == t.TeamId && s.AwayTeamId == i.TeamId) || (s.HomeTeamId == i.TeamId && s.AwayTeamId == t.TeamId)) >= l.PlayEachTimeCount)
                        //    //    continue;
                        //    //if (games.Count(s => (s.HomeTeamId == t.TeamId && s.AwayTeamId == i.TeamId) ||
                        //    //                     (s.HomeTeamId == i.TeamId && s.AwayTeamId == t.TeamId)) >= l.PlayEachTimeCount)
                        //    //    continue;

                        //    // Ensure both teams are within the valid game range (either l.GamesPerSeason or l.GamesPerSeason + 1)
                        //    int teamCountHome = teamGameCount.ContainsKey(t.TeamId) ? teamGameCount[t.TeamId] : 0;
                        //    int teamCountAway = teamGameCount.ContainsKey(i.TeamId) ? teamGameCount[i.TeamId] : 0;

                        //    if (teamCountHome >= l.GamesPerSeason + 1 || teamCountAway >= l.GamesPerSeason + 1)
                        //        continue;

                        //    // Add the game and update game counts
                        //    games.Add(new Game
                        //    {
                        //        HomeTeamId = t.TeamId,
                        //        AwayTeamId = i.TeamId,
                        //    });

                        //    // Update team counts
                        //    teamGameCount[t.TeamId]++;
                        //    teamGameCount[i.TeamId]++;
                        //}
                    }

                    // After initial round-robin scheduling, ensure that every team gets exactly GamesPerSeason games
                    // Loop through each team and fill in any remaining games
                    foreach (var team in teams)
                    {
                        // While a team has fewer games than the target, keep pairing it
                        while (teamGameCount[team.TeamId] < l.GamesPerSeason)
                        {
                            // Find an opponent that also has fewer games
                            var opponent = teams.FirstOrDefault(i => i.TeamId != team.TeamId && teamGameCount[i.TeamId] < l.GamesPerSeason);

                            // If we found a valid opponent, add the game
                            if (opponent != null)
                            {
                                games.Add(new Game
                                {
                                    HomeTeamId = team.TeamId,
                                    AwayTeamId = opponent.TeamId,
                                });

                                teamGameCount[team.TeamId]++;
                                teamGameCount[opponent.TeamId]++;
                            }
                            else
                            {
                                // If no opponent can be found, break out (to avoid infinite loop)
                                break;
                            }
                        }
                    }


                    //foreach(Team t in teams)
                    //{
                    //    foreach(Team i in teams.OrderBy(_ => rng.Next())) //I guess there is an "I" in team
                    //    {
                    //        if (t == i)
                    //            continue;
                    //        if (games.Where(s => (s.HomeTeamId == t.TeamId && s.AwayTeamId == i.TeamId) || (s.HomeTeamId == i.TeamId && s.AwayTeamId == t.TeamId)).Count() >= l.PlayEachTimeCount)
                    //            continue;
                    //        if (games.Where(s => s.HomeTeamId == t.TeamId || s.AwayTeamId == t.TeamId).Count() + teams.Count % 2 > l.GamesPerSeason || games.Where(s => s.AwayTeamId == i.TeamId || s.HomeTeamId == i.TeamId).Count() + teams.Count % 2 > l.GamesPerSeason)
                    //            continue;
                    //        else
                    //        {
                    //            games.Add(new Game
                    //            {
                    //                HomeTeamId = t.TeamId,
                    //                AwayTeamId = i.TeamId,
                    //            });
                    //        }
                    //    }
                    //}

                    games = games.OrderBy(_ => rng.Next()).ToList();    
                    //possibleUnfilteredTimeSlots = possibleUnfilteredTimeSlots.OrderByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[0])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[1])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[2])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[3])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[4])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[5])
                    //    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[6])
                    //    .ThenBy(_ => rng.Next())
                    //    .ToList();

                    foreach(Game g in games) //Remove any time and field combo that is already taken by a saved game
                    {
                        possibleUnfilteredTimeSlots.RemoveAll(s => s.Item1 == g.Field && s.Item2 == g.ChosenScheduleTime);
                    }

;                   foreach (Game g in games)
                    {
                        if(g.ChosenScheduleTime == DateTime.MinValue)
                        {
                            //Get list of possible times then filter out times the teams can't play
                            List<Tuple<Field, DateTime>> availableForTeams = possibleUnfilteredTimeSlots.ToList();
                            List<ExcludedGameDate> excludedGameTimesForBothTeams = dbc.ExcludedGameDates.Where(s => s.Team.TeamId == g.AwayTeamId || s.Team.TeamId == g.HomeTeamId).ToList();

                            List<DateTime> teamsCurrentGames = dbc.Games.Where(s => s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId || s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId).Select(s => s.ChosenScheduleTime).ToList();
                            List<DateTime> teamsCurrentGameDays = dbc.Games.Where(s => s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId || s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId).Select(s => s.ChosenScheduleTime.Date).ToList();

                            foreach (ExcludedGameDate egd in excludedGameTimesForBothTeams)
                            {
                                if(egd.ExcludedTimeEnd == null && egd.ExcludedTimeStart == null) //Date Only Restriction
                                {
                                    availableForTeams.RemoveAll(s => s.Item2.Date == egd.ExcludedDate.Date);
                                }
                                else if(egd.ExcludedTimeStart != null && egd.ExcludedTimeEnd == null) //Weird state, but since it's a start with no end then only allow games before and ending before this time
                                {
                                    availableForTeams.RemoveAll(s => s.Item2.AddMinutes(l.GameLengthWindow * -1).TimeOfDay <= egd.ExcludedTimeStart?.TimeOfDay && s.Item2.Date == egd.ExcludedDate);
                                }
                                else if (egd.ExcludedTimeStart == null && egd.ExcludedTimeEnd != null) //Another weird state.  Only allow games after or at the selected time
                                {
                                    availableForTeams.RemoveAll(s => s.Item2.TimeOfDay >= egd.ExcludedTimeStart?.TimeOfDay && s.Item2.Date == egd.ExcludedDate);
                                }
                                else if(egd.ExcludedTimeStart != null && egd.ExcludedTimeEnd != null) //Time restrictions that take out a section of a day
                                {
                                    availableForTeams.RemoveAll(s => s.Item2.AddMinutes(l.GameLengthWindow * -1).TimeOfDay <= egd.ExcludedTimeStart?.TimeOfDay && s.Item2.TimeOfDay >= egd.ExcludedTimeStart?.TimeOfDay && s.Item2.Date == egd.ExcludedDate);
                                }
                            }

                            if(teamsCurrentGames.Where(s => s == availableForTeams.First().Item2 || s.Date == availableForTeams.First().Item2.Date).Count() > 0)
                            {

                            }

                            //Remove times that would put the two teams playing each other again in less than eight days
                            if(dbc.Games.Include(s => s.Field).Where(s => ((s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId) && (s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId))).Count() > 0)
                                availableForTeams.RemoveAll(r => dbc.Games.Include(s => s.Field).Where(s => ((s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId) && (s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId)) && r.Item2 > s.ChosenScheduleTime.AddDays(-8) && r.Item2 < s.ChosenScheduleTime.AddDays(8)).Count() > 0);

                            List<int> teamsWithGameInFirstEightDays = dbc.Games.Where(s => s.ChosenScheduleTime <= ((DateTime) currentLeagueSeason.StartDate).AddDays(8) && s.League == l).Select(s => s.AwayTeamId).ToList();
                            teamsWithGameInFirstEightDays.AddRange(dbc.Games.Where(s => s.ChosenScheduleTime <= ((DateTime)currentLeagueSeason.StartDate).AddDays(8) && s.League == l).Select(s => s.HomeTeamId).ToList());

                            int teamsInLeague = l.Teams.Count();

                            if ((!teamsWithGameInFirstEightDays.Contains(g.HomeTeamId) || !teamsWithGameInFirstEightDays.Contains(g.AwayTeamId)) && teamsWithGameInFirstEightDays.Where(s => (s == g.HomeTeamId || s == g.AwayTeamId) && (s == g.AwayTeamId || s == g.HomeTeamId)).Count() < 2) //Make sure that at least one of the times doesn't have an early season game, and that the teams aren't playing more than two in the opening eight days
                            {
                                List<Tuple<Field, DateTime>> tempAvailable = availableForTeams.Where(s => !teamsCurrentGames.Contains(s.Item2) && s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) //Try to make it so the team doesn't play twice in the same day and time. Also make sure that every team has at least one game in the first two Saturdays.
                                .OrderBy(s => teamsCurrentGameDays.Contains(s.Item2.Date)) //Try to make it so teams don't have to play twice in the same day
                                .ThenBy(t => dbc.Games.Include(s => s.Field).Where(s => ((s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId) && (s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId)) && t.Item2 > s.ChosenScheduleTime.AddDays(-10) && t.Item2 < s.ChosenScheduleTime.AddDays(10)).Count() > 0) //Make it so the teams don't have to play each other too often.
                                .ThenByDescending(s => s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) //Make sure that the top set of days is included
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[0]) //Prioritize the game schedules to use the most preferred day of week.  Sunday and week games are very likely if you don't here.
                                //.ThenBy(_ => rng.Next())
                                .ToList();

                                if (tempAvailable.Count() > 0)
                                    availableForTeams = tempAvailable;
                                else
                                {
                                    availableForTeams = availableForTeams.Where(s => !teamsCurrentGames.Contains(s.Item2) && (!(s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) || teamsWithGameInFirstEightDays.Distinct().Count() == teamsInLeague)) //Try to make it so the team doesn't play twice in the same day and time
                                    .OrderBy(s => teamsCurrentGameDays.Contains(s.Item2.Date)) //Try to make it so teams don't have to play twice in the same day
                                    .ThenBy(t => dbc.Games.Include(s => s.Field).Where(s => ((s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId) && (s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId)) && t.Item2 > s.ChosenScheduleTime.AddDays(-10) && t.Item2 < s.ChosenScheduleTime.AddDays(10)).Count() > 0) //Make it so the teams don't have to play each other too often.
                                    .ThenBy(s => s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) //Do this to encourage the later schedules to be picked first when teams already have a game in the first two Saturdays
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[0]) //Prioritize the game schedules to use the most preferred day of week
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[1])
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[2])
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[3])
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[4])
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[5])
                                    .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[6])
                                    .ThenBy(_ => rng.Next())
                                    .ToList();
                                }
                            }
                            else
                            {
                                availableForTeams = availableForTeams.Where(s => !teamsCurrentGames.Contains(s.Item2) && (!(s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) || teamsWithGameInFirstEightDays.Distinct().Count() == teamsInLeague)) //Try to make it so the team doesn't play twice in the same day and time
                                .OrderBy(s => teamsCurrentGameDays.Contains(s.Item2.Date)) //Try to make it so teams don't have to play twice in the same day
                                .ThenBy(t => dbc.Games.Include(s => s.Field).Where(s => ((s.HomeTeamId == g.HomeTeamId || s.HomeTeamId == g.AwayTeamId) && (s.AwayTeamId == g.AwayTeamId || s.AwayTeamId == g.HomeTeamId)) && t.Item2 > s.ChosenScheduleTime.AddDays(-10) && t.Item2 < s.ChosenScheduleTime.AddDays(10)).Count() > 0) //Make it so the teams don't have to play each other too often.
                                .ThenBy(s => s.Item2.Date >= currentLeagueSeason.StartDate && s.Item2.Date <= ((DateTime)currentLeagueSeason.StartDate).Date.AddDays(8)) //Do this to encourage the later schedules to be picked first when teams already have a game in the first two Saturdays
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[0]) //Prioritize the game schedules to use the most preferred day of week
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[1])
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[2])
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[3])
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[4])
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[5])
                                .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[6])
                                .ThenBy(_ => rng.Next())
                                .ToList();
                            }

                            if (availableForTeams.Count == 0)
                                continue;
                            Tuple<Field, DateTime> selected = availableForTeams.First();
                            possibleUnfilteredTimeSlots.Remove(selected);
                            g.Field = selected.Item1;
                            g.ChosenScheduleTime = selected.Item2;
                            g.League = l;


                        }
                        if(g.GameId == 0)
                            dbc.Games.Add(g);

                        dbc.SaveChanges();
                    }

                    //Do some last minute checks
                    foreach(Game g in games)
                    {

                    }
                }
                dbc.SaveChanges();
                return games;
            }
            return games;
        }
    }
}
