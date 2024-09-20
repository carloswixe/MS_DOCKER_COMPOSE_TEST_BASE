using DataAccesLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace NET_TEST_BASE.DTOs
{
    public class PagoDto
    {
        [Required]
        public string Concepto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de productos debe ser mayor que 0.")]
        public int CantidadProductos { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor que 0.")]
        public decimal MontoTotal { get; set; }
        
        public string Estatus { get; set; } = "Pendiente"; // Por defecto, el estatus inicial será "Pendiente".

        // Relaciones con los catálogos        
        public int OrdenanteId { get; set; }

        public int BeneficiarioId { get; set; }
    }
}
