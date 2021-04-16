using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using CalvinProject.Models;
using CalvinProject.Interfaces;

namespace CalvinProject.Controllers
{
    public class LoginController : Controller
    {
        private IUserInterface _userRepository;
        public LoginController(IUserInterface userRepository)
        {
            _userRepository = userRepository;
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoggedIn(string user)
        {
            var userlogin = JsonConvert.DeserializeObject<User>(user);
            var userRequest = _userRepository.GetUser(userlogin.Email);
            if(userlogin.Email == userRequest.Email && userlogin.Password == userRequest.Password) {
                HttpContext.Session.SetInt32("UserId", userRequest.Id);
                return Json(true);
            } else {
                return Json(false);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var user = new User();
            return View();
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
