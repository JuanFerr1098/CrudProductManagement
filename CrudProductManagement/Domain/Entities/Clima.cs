namespace Domain.Entities
{
    public class Clima
    {
        public string Ciudad { get; set; }
        public string Descripcion { get; set; }
        public decimal Temperatura { get; set; }
        public decimal SensacionTermica { get; set; }
        public int Humedad { get; set; }
        public decimal VelocidadViento { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
