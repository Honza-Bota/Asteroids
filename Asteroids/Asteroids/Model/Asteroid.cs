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
                        string hazardous,
                        string close_approach_date,
                        string relative_velocity_KmPs,
                        string miss_distance_Km,
                        string orbiting_body,
                        string first_observation_date,
                        string last_observation_date,
                        string sentry_object)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"Hodnota {nameof(id)} nemůže být null nebo prázdná.", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Hodnota {nameof(name)} nemůže být null nebo prázdná.", nameof(name));
            }

            if (string.IsNullOrEmpty(hazardous))
            {
                throw new ArgumentException($"Hodnota {nameof(hazardous)} nemůže být null nebo prázdná.", nameof(hazardous));
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

            if (string.IsNullOrEmpty(sentry_object))
            {
                throw new ArgumentException($"Hodnota {nameof(sentry_object)} nemůže být null nebo prázdná.", nameof(sentry_object));
            }

            Id = id;
            Name = name;
            Estimated_diameter_M = $"{Math.Round(estimated_diameter_M_Min, 2)} - {Math.Round(estimated_diameter_M_Max, 2)} m";
            Hazardous = hazardous;
            Close_approach_date = close_approach_date;
            Relative_velocity_KmPs = $"{relative_velocity_KmPs.Remove(8)} Km/s";
            Miss_distance_Km = $"{miss_distance_Km.Remove(8)} Km";
            Orbiting_body = orbiting_body;
            First_observation_date = first_observation_date;
            Last_observation_date = last_observation_date;
            Sentry_object = sentry_object;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Estimated_diameter_M { get; set; }
        public string Hazardous { get; set; }
        public string Close_approach_date { get; set; }
        public string Relative_velocity_KmPs { get; set; }
        public string Miss_distance_Km { get; set; }
        public string Orbiting_body { get; set; }
        public string First_observation_date { get; set; }
        public string Last_observation_date { get; set; }
        public string Sentry_object { get; set; }

    }
}
