using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            return View();
        }

        [HttpPost]
        public IActionResult LoggedIn([FromBody] User data)
        {
            var loginResponse = new LoginResponse();
            if (!string.IsNullOrEmpty(data?.UserName) && !string.IsNullOrEmpty(data?.Password))
            {
                loginResponse.User = _userRepository.GetUser(data.Email);

                if (data.Email != null && data?.Email == loginResponse.User.Email)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    loginResponse.ErrorMessage = "Username and or password is incorrect";
                    loginResponse.Success = false;
                    return Json(loginResponse);
                }
            }
            else
            {
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
        public IActionResult RegisterNewUser(string data)
        {
            var newUser = JsonConvert.DeserializeObject<User>(data);
            _userRepository.AddNewUser(newUser);
            return Json("new user registered");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
