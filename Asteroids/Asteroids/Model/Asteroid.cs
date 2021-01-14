using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Model
{
     public class Asteroid
     {
        public Asteroid(string id,
                        string name,
                        double estimated_diameter_M_Min,
                        double estimated_diameter_M_Max,
                        bool hazardous,
                        string close_approach_date,
                        string relative_velocity_KmPs,
                        string miss_distance_Km,
                        string orbiting_body,
                        string first_observation_date,
                        string last_observation_date,
                        bool sentry_object)
        {
            #region StringValidation

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"Hodnota {nameof(id)} nemůže být null nebo prázdná.", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Hodnota {nameof(name)} nemůže být null nebo prázdná.", nameof(name));
            }

            if (string.IsNullOrEmpty(close_approach_date))
            {
                throw new ArgumentException($"Hodnota {nameof(close_approach_date)} nemůže být null nebo prázdná.", nameof(close_approach_date));
            }

            if (string.IsNullOrEmpty(orbiting_body))
            {
                throw new ArgumentException($"Hodnota {nameof(orbiting_body)} nemůže být null nebo prázdná.", nameof(orbiting_body));
            }

            if (string.IsNullOrEmpty(first_observation_date))
            {
                throw new ArgumentException($"Hodnota {nameof(first_observation_date)} nemůže být null nebo prázdná.", nameof(first_observation_date));
            }

            if (string.IsNullOrEmpty(last_observation_date))
            {
                throw new ArgumentException($"Hodnota {nameof(last_observation_date)} nemůže být null nebo prázdná.", nameof(last_observation_date));
            } 
            #endregion

            Id = id;
            Name = name;
            Estimated_diameter_M = $"{Math.Round(estimated_diameter_M_Min, 2)} - {Math.Round(estimated_diameter_M_Max, 2)} m";
            Hazardous = hazardous == true ? "Ano" : "Ne";
            Close_approach_date = EditDate(close_approach_date);
            Relative_velocity_KmPs = $"{relative_velocity_KmPs.Remove(relative_velocity_KmPs.IndexOf('.') + 4)} Km/s";
            Miss_distance_Km = $"{miss_distance_Km.Remove(miss_distance_Km.IndexOf('.') + 4)} Km";
            Orbiting_body = orbiting_body;
            First_observation_date = EditDate(first_observation_date);
            Last_observation_date = EditDate(last_observation_date);
            Sentry_object = sentry_object == true ? "Ano" : "Ne";
        }

        public string Id { get; set; }
        //id
        public string Name { get; set; }
        //jméno
        public string Estimated_diameter_M { get; set; }
        //průměrná velikost v metrech
        public string Hazardous { get; set; }
        //nebezpečný
        public string Close_approach_date { get; set; }
        //nejbližší datum příletu
        public string Relative_velocity_KmPs { get; set; }
        //relativní rychlost v kilometrech za sekundu
        public string Miss_distance_Km { get; set; }
        //vzdálenost v kilometrech
        public string Orbiting_body { get; set; }
        //orbitální těleso
        public string First_observation_date { get; set; }
        //první pozorování
        public string Last_observation_date { get; set; }
        //poslední pozorování
        public string Sentry_object { get; set; }
        //je objekt sledovaný


        private string EditDate(string close_approach_date)
        {
            string[] iteomsOfDate = close_approach_date.Split('-');

            int day, month, year;

            day = Convert.ToInt32(iteomsOfDate[2]);
            month = Convert.ToInt32(iteomsOfDate[1]);
            year = Convert.ToInt32(iteomsOfDate[0]);

            return new DateTime(year, month, day).ToLongDateString();
        }

    }
}
