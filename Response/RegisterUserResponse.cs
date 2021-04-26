using CalvinProject.Models;

namespace CalvinProject.Response
{
    public class RegisterUserResponse
    {
        public User NewUser { get; set; }
        public bool Success { get; set; }
        public string ErrorMesssage { get; set; }
    }
}
