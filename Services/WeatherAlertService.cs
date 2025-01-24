using SportsScheduleProLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsScheduleProLibrary.Services
{
    public class WeatherAlertService
    {
        public static Alert SendWeatherAlert(Club club = null, List<Coach> coaches = null, Field field = null, League league = null, Location location = null, Referee referee = null, Team team = null, Tournament tournament = null)
        {
            Alert alert = new Alert
            {
                //AlertType = AlertType.Weather,
                Message = "Weather alert - Fields will be closed due to inclement weather.",
                AlertType = AlertType.Weather,
                AlertDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2).Date,
                
            };

            if (team != null)
            {
                List<AlertContact> contacts = new List<AlertContact>();
                //Send Alerts To Group
                foreach (Player player in team.Players)
                {
                    contacts.AddRange(player.AlertContacts);
                }

                alert.AlertContacts = contacts;
                return alert;
            }
            throw new NotImplementedException();
        }
    }
}
