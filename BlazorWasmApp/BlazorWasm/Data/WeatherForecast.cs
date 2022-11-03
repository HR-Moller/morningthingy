namespace BlazorWasm.Data
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Rain rain { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Rain
    {
        public double _3h { get; set; }
    }

    public class Root
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }


    
    
}

namespace BlazorWasm.Data.Coordinates
{
    public class Root
    {
        public string name { get; set; }
        public LocalNames local_names { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }

    public class LocalNames
    {
        public string af { get; set; }
        public string ar { get; set; }
        public string ascii { get; set; }
        public string az { get; set; }
        public string bg { get; set; }
        public string ca { get; set; }
        public string da { get; set; }
        public string de { get; set; }
        public string el { get; set; }
        public string en { get; set; }
        public string eu { get; set; }
        public string fa { get; set; }
        public string feature_name { get; set; }
        public string fi { get; set; }
        public string fr { get; set; }
        public string gl { get; set; }
        public string he { get; set; }
        public string hi { get; set; }
        public string hr { get; set; }
        public string hu { get; set; }
        public string id { get; set; }
        public string it { get; set; }
        public string ja { get; set; }
        public string la { get; set; }
        public string lt { get; set; }
        public string mk { get; set; }
        public string nl { get; set; }
        public string no { get; set; }
        public string pl { get; set; }
        public string pt { get; set; }
        public string ro { get; set; }
        public string ru { get; set; }
        public string sk { get; set; }
        public string sl { get; set; }
        public string sr { get; set; }
        public string th { get; set; }
        public string tr { get; set; }
        public string vi { get; set; }
        public string zu { get; set; }
    }
}