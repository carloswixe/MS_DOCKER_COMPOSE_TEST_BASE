using System.ComponentModel.DataAnnotations;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.DTOs
{
    public class OrdenanteDTO
    {
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
    }
}
