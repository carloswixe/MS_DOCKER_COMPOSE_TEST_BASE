namespace NET_TEST_BASE.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public int CantidadProductos { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estatus { get; set; } // Pendiente, Pagado, Rechazado, etc.


        // Claves foráneas
        public int OrdenanteId { get; set; }
        public Ordenante Ordenante { get; set; }

        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
