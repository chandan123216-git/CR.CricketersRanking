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
    public class CricktersPollController : Controller
    {
        public readonly IUserService UserService;

        public CricktersPollController()
        {
            UserService = new UserService();
        }
        public IActionResult CricktersPoll()
        {
            var Poll = new CricktersPollModel();
            Poll.PollResult = UserService.GetUserPoll();
            return View(Poll);
        }
    }
}



