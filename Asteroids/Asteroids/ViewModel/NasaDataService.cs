using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asteroids.ViewModel
{
    class NasaDataService
    {

        private HttpClient client = new HttpClient();


        const string API = "https://api.nasa.gov/neo/rest/v1/neo/browse?api_key=XIjJ0o45nFWPaEhXubCOZJ3LISFNwyH9ffmaeuu5";


        public async Task<NasaResponse> SnatchData()
        {
            HttpResponseMessage httpResponseMessage = await client.GetAsync(API).ConfigureAwait(false);
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NasaResponse>(json);
        }

        public List<Asteroid> GetAsteroids()
        {                
            try
            {
                return MapNasaResponseToAsteroids(SnatchData().Result);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }


        private List<Asteroid> MapNasaResponseToAsteroids(NasaResponse nasaResponse)
        {
            List<Asteroid> asteroids = new List<Asteroid>();
            foreach (NearEarthObject nearEarthObject in nasaResponse.near_earth_objects) //každej jeden asteroid
            {
                List<CloseApproachData> l_close_approach_data = nearEarthObject.close_approach_data; //přílety
                CloseApproachData closeApproachData = FindNearestApproach(l_close_approach_data);

                asteroids.Add(new Asteroid(nearEarthObject.id,
                    nearEarthObject.name,
                    nearEarthObject.estimated_diameter.meters.estimated_diameter_min,
                    nearEarthObject.estimated_diameter.meters.estimated_diameter_max,
                    nearEarthObject.is_potentially_hazardous_asteroid.ToString(),
                    closeApproachData.close_approach_date,
                    closeApproachData.relative_velocity.kilometers_per_second,
                    closeApproachData.miss_distance.kilometers,
                    closeApproachData.orbiting_body,
                    nearEarthObject.orbital_data.first_observation_date,
                    nearEarthObject.orbital_data.last_observation_date,
                    nearEarthObject.is_sentry_object.ToString())) ;

            }
            return asteroids;
        }

        private CloseApproachData FindNearestApproach(List<CloseApproachData> l_close_approach_data)
        {
            int today = DateTime.Now.Year;
            List<int> listOfYears = new List<int>();
            foreach (CloseApproachData item in l_close_approach_data)
            {
                listOfYears.Add(Convert.ToInt32(item.close_approach_date.Remove(4)));
            }
            int closest = listOfYears.OrderBy(item => Math.Abs(today - item)).First();
            foreach (CloseApproachData item in l_close_approach_data)
            {
                if (closest == Convert.ToInt32(item.close_approach_date.Remove(4))) return item;
            }
            return l_close_approach_data[0]; //nemělo by se stát
        }
    }
}
