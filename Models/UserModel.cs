using CalvinProject.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CalvinProject.Models
{
    public class User: BaseClass
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; } = true;
        [Required]
        public string UserRole { get; set; } = Constants.User;
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string JobDescription { get; set; }
    }
}