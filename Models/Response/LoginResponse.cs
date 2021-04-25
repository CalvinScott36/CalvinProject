namespace CalvinProject.Models.Response
{
    public class LoginResponse
    {
        public User User { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public string UrlLocation { get; set; } = "";
    }
}
