using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.CricketerRanking.Models;
using CR.CricketerRanking.Service.Contract;
using CR.CricketerRanking.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace CR.CricketerRanking.Controllers
{
    public class CricktersPollWithoutLoginController : Controller
    {
        public readonly IUserService userService;

        public CricktersPollWithoutLoginController()
        {
            userService = new UserService();
        }

        public IActionResult CricktersPollWithoutLogin()
        {
            var Poll = new CricktersPollWithoutLoginModel();
            Poll.PollResult = userService.GetUserPoll();
            return View(Poll);
        }
    }
}
