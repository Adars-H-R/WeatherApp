using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherResponsexml
    {
        public City city { get; set; }
        public Temperature temperature { get; set; }
        public Feels_like feels_like { get; set; }
        public Humidity humidity { get; set; }
        public Pressure pressure { get; set; }
       // public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Visibility visibility { get; set; }
        public Precipitation precipitation { get; set; }
        public Weather weather { get; set; }
        public Lastupdate lastupdate { get; set; }
    }


    public class Sun
    {
        public DateTime rise { get; set; }
        public DateTime set { get; set; }
    }
    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
        public Sun sun { get; set; }
    }
    public class Temperature
    {
        public string value { get; set; }
        public string min { get; set; }
        public string max { get; set; }
        public string unit { get; set; }
    }
    public class Feels_like
    {
        public string value { get; set; }
        public string unit { get; set; }
    }
    public class Humidity
    {
        public string value { get; set; }
        public string unit { get; set; }
    }
    public class Pressure
    {
        public string value { get; set; }
        public string unit { get; set; }
    }
    public class Speed
    {
        public string value { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
    }
    public class Direction
    {
        public string value { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Visibility
    {
        public string value { get; set; }

    }
    public class Precipitation
    {
        public string mode { get; set; }
    }

    public class Lastupdate
    {
        public DateTime value { get; set; }
    }

}
