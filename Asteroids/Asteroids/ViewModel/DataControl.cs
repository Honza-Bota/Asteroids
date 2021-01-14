using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;

namespace Asteroids.ViewModel
{
    class DataControl
    {
        const string api = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=XIjJ0o45nFWPaEhXubCOZJ3LISFNwyH9ffmaeuu5";
        bool edit = false;

        public List<Asteroid> GetAllAsteroids(out string _lastUpdate)
        {                
            //vytvoření listu asteroidů a navrácení do formu
            try 
            { 
                List<Asteroid> asteroids = ConvertResponseToAsteroids(DownloadData().Result);
                _lastUpdate = edit ? Application.Current.Properties["updateDate"].ToString() : DateTime.Now.ToString();
                return asteroids;
            }
            catch (Exception err) { throw new Exception(err.Message); }
        }

        async Task<NasaApiResponse> DownloadData()
        {
            //stažení a deserialzace jsonu
            HttpClient httpc = new HttpClient();

            try
            {
                string json;
                HttpResponseMessage httpResponseMessage = await httpc.GetAsync(api).ConfigureAwait(false);
                //httpResponseMessage.EnsureSuccessStatusCode();
                if (httpResponseMessage.IsSuccessStatusCode == false)
                {
                    json = Application.Current.Properties["oldJson"].ToString();
                    edit = true;
                }
                json = await httpResponseMessage.Content.ReadAsStringAsync();
                SaveJson(json, DateTime.Now);
                edit = false;
                return JsonConvert.DeserializeObject<NasaApiResponse>(json);
            }
            catch (HttpRequestException err)
            {

                throw new HttpRequestException(err.Message);
            }
        }

        private void SaveJson(string json, DateTime now)
        {
            Application.Current.Properties["oldJson"] = json;
            Application.Current.Properties["updateDate"] = now.Ticks;

            Application.Current.SavePropertiesAsync();

            //Debug.Print(Application.Current.Properties.Count.ToString()+"azor");
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

        public List<Asteroid> Update(out string lastUpdate)
        {
            List<Asteroid> asteroids;

            asteroids = GetAllAsteroids(out lastUpdate);

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
