using System.ComponentModel.DataAnnotations;

namespace API_Morada.Models
{
    public class Morada
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string morada { get; set; }
        [Required]
        public string codigoPostal { get; set; }
        [Required]
        public string rua { get; set; }
        [Required]
        public string freguesia { get; set; }
        [Required]
        public string concelho { get; set; }
        [Required]
        public string distrito { get; set; }
        [Required]
        public string pais { get; set; }
    }
}
