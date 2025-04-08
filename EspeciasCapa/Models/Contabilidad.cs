namespace EspeciasCapa.Models
{
    public class Contabilidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // "Ingreso" o "Gasto"
    }
}
