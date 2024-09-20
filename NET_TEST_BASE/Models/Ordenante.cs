using System.Text.Json.Serialization;

namespace NET_TEST_BASE.Models
{
    public class Ordenante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        // Relación con la tabla Pago
        public ICollection<Pago> Pagos { get; set; }
    }
}
