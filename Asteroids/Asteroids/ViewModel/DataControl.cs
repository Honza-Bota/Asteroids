﻿using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asteroids.ViewModel
{
    class DataControl
    {
        const string API = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=XIjJ0o45nFWPaEhXubCOZJ3LISFNwyH9ffmaeuu5";

        public List<Asteroid> GetAllAsteroids()
        {                
            //vytvoření listu asteroidů a navrácení do formu
            try { return ConvertResponseToAsteroids(DownloadData().Result); }
            catch (Exception err) { throw new Exception(err.Message); }
        }

        public async Task<NasaApiResponse> DownloadData()
        {
            //stažení a deserialzace jsonu
            HttpClient httpc = new HttpClient();

            try
            {
                HttpResponseMessage httpResponseMessage = await httpc.GetAsync(API).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NasaApiResponse>(json);
            }
            catch (HttpRequestException err)
            {

                throw new HttpRequestException(err.Message);
            }
        }

        private List<Asteroid> ConvertResponseToAsteroids(NasaApiResponse response)
        {
            List<Asteroid> asteroids = new List<Asteroid>();

            foreach (NearEarthObject neo in response.NearEarthObjectsList)
            {
                CloseApproachData cad = FindNearestApproach(neo.CloseApproachData);

                asteroids.Add(new Asteroid(
                    neo.Id,
                    neo.Name,
                    neo.EstimatedDiameter.Meters.EstimatedDiameterMin,
                    neo.EstimatedDiameter.Meters.EstimatedDiameterMax,
                    neo.IsPotentiallyHazardousAsteroid,
                    cad.CloseApproachDate,
                    cad.RelativeVelocity.KilometersPerSecond,
                    cad.MissDistance.Kilometers,
                    cad.OrbitingBody,
                    neo.OrbitalData.FirstObservationDate,
                    neo.OrbitalData.LastObservationDate,
                    neo.IsSentryObject));
            }

            return asteroids;
        }

        internal List<Asteroid> Update(out string lastUpdate)
        {
            List<Asteroid> asteroids;

            asteroids = GetAllAsteroids();
            lastUpdate = DateTime.Now.ToString();

            return asteroids;
        }

        private CloseApproachData FindNearestApproach(List<CloseApproachData> l_cad)
        {
            List<int> years = new List<int>();
            int date = DateTime.Now.Year;

            //roky příletu
            foreach (CloseApproachData item in l_cad)
            {
                years.Add(Convert.ToInt32(item.CloseApproachDate.Remove(4)));
            }

            //nalezení nejbližšího data příletu
            int closest;
            do
            {
              closest = years.OrderBy(item => Math.Abs(date - item)).First();

                if (closest < date) date++;
                else continue;
            } while (closest < date);

            //nalezení nejbližšího záznamu v závislosti na nejbližším datu
            foreach (CloseApproachData item in l_cad)
            {
                if (closest == Convert.ToInt32(item.CloseApproachDate.Remove(4))) return item;
            }

            return null;
        }
    }
}
