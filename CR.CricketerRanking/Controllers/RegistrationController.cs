using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.CricketerRanking.Service.Contract;
using CR.CricketerRanking.Service.Implement;
using CR.CricketerRanking.Type.Types;
using Microsoft.AspNetCore.Mvc;

namespace CR.CricketerRanking.Controllers
{   
    public class RegistrationController : Controller
    {
        private readonly IUserService UserService;

        public RegistrationController()
        {
            UserService = new UserService();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public void RegisterUser([FromBody] User user)
        {
            user.IsActive = true;
            user.CreatedBy = 0;
            user.CreatedDate = DateTime.Now;
            user.UpdatedBy = 0;
            user.UpdatedDate = DateTime.Now;

            UserService.AddUser(user);
        }
    }
}
