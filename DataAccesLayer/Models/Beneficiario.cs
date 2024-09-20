using System.Text.Json.Serialization;

namespace DataAccesLayer.Models
{
    public class Beneficiario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        // Relación con la tabla Pago
        public ICollection<Pago> Pagos { get; set; }
    }
}
