using CVC_Poc.Models;
using CVC_Poc.Models.Constant;
using CVC_Poc.Models.Domain;
using CVC_Poc.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CVC_Poc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString(CVCConstants.SessionName);
            if (!string.IsNullOrEmpty(user))
            {
                //var userData = JsonConvert.DeserializeObject<UserSession>(user);
                
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            var user = HttpContext.Session.GetString(CVCConstants.SessionName);
            if (!string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm login)
        {
            if (ModelState.IsValid)
            {

                var user = CVCConstants.Users.FirstOrDefault(c => c.Email.ToLower() == login.Email.ToLower() && c.Password == login.Password);
                if (user != null)
                {
                    var userSession = new UserSession { Id = user.Id, Roles = user.Roles, Name = user.Name };
                    var userData = JsonConvert.SerializeObject(userSession);
                    HttpContext.Session.SetString(CVCConstants.SessionName, userData);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
