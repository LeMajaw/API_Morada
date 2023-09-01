using System.ComponentModel.DataAnnotations;

namespace API_Morada.Models
{
    public class Login
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public string email { get; set; }
    }
}
