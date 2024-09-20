using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_TEST_BASE_WCF
{
    public class Pago
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public int CantidadProductos { get; set; }
        public int OrdenanteId { get; set; }
        public int BeneficiarioId { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estatus { get; set; }
    }
}