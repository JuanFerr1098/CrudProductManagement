namespace Domain.Entities
{
    public class Clima
    {
        public string Ciudad { get; set; }
        public string Descripcion { get; set; }
        public decimal Temperatura { get; set; }
        public double SensacionTermica { get; set; }
        public int Humedad { get; set; }
        public double VelocidadViento { get; set; }
        public DateTime FechaConsulta { get; set; }
    }

    public class ClimaResponse
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        public Wind Wind { get; set; }
        public List<WeatherData> Weather { get; set; }
    }

    public class MainData
    {
        public decimal Temp { get; set; }
        public double Feels_Like { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherData
    {
        public string Description { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
    }
}
