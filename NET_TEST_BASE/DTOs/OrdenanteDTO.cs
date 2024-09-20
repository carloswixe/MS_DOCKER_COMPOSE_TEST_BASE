using System.ComponentModel.DataAnnotations;

namespace NET_TEST_BASE.DTOs
{
    public class OrdenanteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
