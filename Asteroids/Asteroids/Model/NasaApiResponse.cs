using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Asteroids.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class Page
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("total_elements")]
        public int TotalElements { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }

    public class Kilometers
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Meters
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Miles
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Feet
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Kilometers Kilometers { get; set; }

        [JsonProperty("meters")]
        public Meters Meters { get; set; }

        [JsonProperty("miles")]
        public Miles Miles { get; set; }

        [JsonProperty("feet")]
        public Feet Feet { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonProperty("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonProperty("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonProperty("astronomical")]
        public string Astronomical { get; set; }

        [JsonProperty("lunar")]
        public string Lunar { get; set; }

        [JsonProperty("kilometers")]
        public string Kilometers { get; set; }

        [JsonProperty("miles")]
        public string Miles { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonProperty("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonProperty("epoch_date_close_approach")]
        public object EpochDateCloseApproach { get; set; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonProperty("miss_distance")]
        public MissDistance MissDistance { get; set; }

        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class OrbitClass
    {
        [JsonProperty("orbit_class_type")]
        public string OrbitClassType { get; set; }

        [JsonProperty("orbit_class_range")]
        public string OrbitClassRange { get; set; }

        [JsonProperty("orbit_class_description")]
        public string OrbitClassDescription { get; set; }
    }

    public class OrbitalData
    {
        [JsonProperty("orbit_id")]
        public string OrbitId { get; set; }

        [JsonProperty("orbit_determination_date")]
        public string OrbitDeterminationDate { get; set; }

        [JsonProperty("first_observation_date")]
        public string FirstObservationDate { get; set; }

        [JsonProperty("last_observation_date")]
        public string LastObservationDate { get; set; }

        [JsonProperty("data_arc_in_days")]
        public int DataArcInDays { get; set; }

        [JsonProperty("observations_used")]
        public int ObservationsUsed { get; set; }

        [JsonProperty("orbit_uncertainty")]
        public string OrbitUncertainty { get; set; }

        [JsonProperty("minimum_orbit_intersection")]
        public string MinimumOrbitIntersection { get; set; }

        [JsonProperty("jupiter_tisserand_invariant")]
        public string JupiterTisserandInvariant { get; set; }

        [JsonProperty("epoch_osculation")]
        public string EpochOsculation { get; set; }

        [JsonProperty("eccentricity")]
        public string Eccentricity { get; set; }

        [JsonProperty("semi_major_axis")]
        public string SemiMajorAxis { get; set; }

        [JsonProperty("inclination")]
        public string Inclination { get; set; }

        [JsonProperty("ascending_node_longitude")]
        public string AscendingNodeLongitude { get; set; }

        [JsonProperty("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonProperty("perihelion_distance")]
        public string PerihelionDistance { get; set; }

        [JsonProperty("perihelion_argument")]
        public string PerihelionArgument { get; set; }

        [JsonProperty("aphelion_distance")]
        public string AphelionDistance { get; set; }

        [JsonProperty("perihelion_time")]
        public string PerihelionTime { get; set; }

        [JsonProperty("mean_anomaly")]
        public string MeanAnomaly { get; set; }

        [JsonProperty("mean_motion")]
        public string MeanMotion { get; set; }

        [JsonProperty("equinox")]
        public string Equinox { get; set; }

        [JsonProperty("orbit_class")]
        public OrbitClass OrbitClass { get; set; }
    }

    public class NearEarthObject
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_limited")]
        public string NameLimited { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonProperty("orbital_data")]
        public OrbitalData OrbitalData { get; set; }

        [JsonProperty("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }

    public class Root
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("near_earth_objects")]
        public List<NearEarthObject> NearEarthObjects { get; set; }
    }

    class NasaApiResponse
    {
        [JsonProperty("near_earth_objects")]
        public IList<NearEarthObject> NearEarthObjectsList { get; set; }
    }


}
