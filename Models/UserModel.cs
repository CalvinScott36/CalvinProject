using System.ComponentModel.DataAnnotations;

namespace CalvinProject.Models
{
    public class User: BaseClass
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        [Required]
        public string UserRole { get; set; }
    }
}