using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CalvinProject.Models;
using CalvinProject.Interfaces;
using CalvinProject.Models.Response;

namespace CalvinProject.Controllers
{
    public class LoginController : Controller
    {
        private IUserInterface _userRepository;
        public LoginController(IUserInterface userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("UserId", null);
            return View();
        }

        [HttpPost]
        public IActionResult LoggedIn([FromBody] User data)
        {
            var loginResponse = new LoginResponse();
            if (!string.IsNullOrEmpty(data?.UserName) && !string.IsNullOrEmpty(data?.Password))
            {
                loginResponse = new LoginResponse
                {
                    User = new User { UserName = data.UserName, Password = data.Password }
                };
                loginResponse.User = _userRepository.GetUser(loginResponse);

                if (loginResponse.User.Email != null && loginResponse.User.Password != null)
                {
                    HttpContext.Session.SetString("UserId", loginResponse.User.Id.ToString());
                    loginResponse.Success = true;
                    loginResponse.UrlLocation = Url.Action("Index", "Home");
                    return Json(loginResponse);
                }
                else
                {
                    HttpContext.Session.SetString("UserId", null);
                    loginResponse.ErrorMessage = "Username and or password is incorrect";
                    loginResponse.Success = false;
                    return Json(loginResponse);
                }
            }
            else
            {
                HttpContext.Session.SetString("UserId", null);
                loginResponse.ErrorMessage = "Username and or password is required";
                return Json(loginResponse);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult RegisterNewUser([FromBody] User data)
        {
            RegisterUserResponse newUser = new RegisterUserResponse { 
                NewUser = data
            };
            _userRepository.AddNewUser(newUser);
            return Json(newUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
