namespace NET_TEST_BASE.Models
{
    public class Bitacora
    {
        public int Id { get; set; }
        public string Entidad { get; set; }  // Por ejemplo, la entidad "Pago"
        public string Accion { get; set; }   // "Insert", "Update", "Delete"
        public DateTime Fecha { get; set; }  // Fecha del evento
        public string Usuario { get; set; }  // Quién realizó la acción (opcional)
        public string Detalles { get; set; } // Descripción del cambio o detalles
    }
}
