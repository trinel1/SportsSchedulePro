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
            List<Club> clubs = dbc.Clubs.Include(s => s.Leagues).ThenInclude(s => s.Fields).Include(s => s.Seasons).Include(s => s.Leagues).ThenInclude(s => s.Teams).ToList();
            List<Game> games = dbc.Games.ToList();

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
                    Season currentLeagueSeason = c.Seasons.OrderByDescending(s => s.EndDate).FirstOrDefault();

                    //Generate list of possible times and places
                    if (l.StartDate == null || l.EndDate == null)
                        continue;
                    else
                    {
                        foreach (Field f in fieldsForLeague)
                        {
                            DateTime currentDate = currentLeagueSeason.StartDate ?? DateTime.Now;
                            while (currentDate < l.EndDate)
                            {
                                if (currentDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    for (int x = 0; x < l.DailyGamesPerFieldSaturday; x++)
                                    {
                                        possibleUnfilteredTimeSlots.Add(new Tuple<Field, DateTime>(f, currentDate.AddHours(l.EarliestGameTimeHourSaturday).AddMinutes(l.EarliestGameTimeMinuteSaturday).AddMinutes(l.GameLengthWindow * x)));
                                    }
                                }
                                else if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    for (int x = 0; x < l.DailyGamesPerFieldSunday; x++)
                                    {
                                        possibleUnfilteredTimeSlots.Add(new Tuple<Field, DateTime>(f, currentDate.AddHours(l.EarliestGameTimeHourSunday).AddMinutes(l.EarliestGameTimeMinuteSunday).AddMinutes(l.GameLengthWindow * x)));
                                    }
                                }
                                else
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
                    List<Team> teams = l.Teams.ToList().OrderBy(_ => rng.Next()).ToList();
                    games = dbc.Games.Where(s => s.League.LeagueId == l.LeagueId).ToList();

                    foreach(Team t in teams)
                    {
                        foreach(Team i in teams) //I guess there is an "I" in team
                        {
                            if (t == i)
                                continue;
                            if (games.Where(s => (s.HomeTeamId == t.TeamId && s.AwayTeamId == i.TeamId) || (s.HomeTeamId ==i.TeamId && s.AwayTeamId == t.TeamId)).Count() >= l.PlayEachTimeCount)
                                continue;
                            else
                            {
                                games.Add(new Game
                                {
                                    HomeTeamId = t.TeamId,
                                    AwayTeamId = i.TeamId,                                   
                                });
                            }
                        }
                    }

                    games = games.OrderBy(_ => rng.Next()).ToList();    
                    possibleUnfilteredTimeSlots = possibleUnfilteredTimeSlots.OrderByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[0])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[1])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[2])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[3])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[4])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[5])
                        .ThenByDescending(s => s.Item2.DayOfWeek == DayOfWeekPreference.ToArray()[6])
                        .ThenBy(_ => rng.Next())
                        .ToList();

                    foreach(Game g in games) //Remove any time and field combo that is already taken by a saved game
                    {
                        possibleUnfilteredTimeSlots.RemoveAll(s => s.Item1 == g.Field && s.Item2 == g.ChosenScheduleTime);
                    }

;                   foreach (Game g in games)
                    {
                        if(g.ChosenScheduleTime == DateTime.MinValue)
                        {
                            Tuple<Field, DateTime> selected = possibleUnfilteredTimeSlots.First();
                            possibleUnfilteredTimeSlots.RemoveAt(0);
                            g.Field = selected.Item1;
                            g.ChosenScheduleTime = selected.Item2;
                            g.League = l;
                        }

                        dbc.Games.Add(g);
                    }
                }
                dbc.SaveChanges();
                return games;
            }
            return games;
        }
    }
}
