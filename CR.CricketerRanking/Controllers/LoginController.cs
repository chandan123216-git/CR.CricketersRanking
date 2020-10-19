using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.CricketerRanking.Helper;
using CR.CricketerRanking.Service.Contract;
using CR.CricketerRanking.Service.Implement;
using CR.CricketerRanking.Type.Types;
using Microsoft.AspNetCore.Mvc;

namespace CR.CricketerRanking.Controllers
{
    public class LoginController : Controller
    {
        public readonly IUserService UserService;

        public LoginController()
        {
            UserService = new UserService();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public bool authenticateUser([FromBody] User user) 
        {
            string Username= user.Username;
            string  Password = user.Password;
            var currentUser = UserService.authenticateUser(Username,Password);

            UserContext.SetUser(currentUser);

            if (currentUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
