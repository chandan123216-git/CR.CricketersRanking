using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CR.CricketerRanking.Helper;
using CR.CricketerRanking.Models;
using CR.CricketerRanking.Service.Contract;
using CR.CricketerRanking.Service.Implement;
using CR.CricketerRanking.Type.Types;
using Microsoft.AspNetCore.Mvc;

namespace CR.CricketerRanking.Controllers
{
    public class UserListController : Controller
    {
        private readonly IUserService UserService;

        private User CurrentUser => UserContext.GetUser();
        public UserListController()
        {
            UserService = new UserService();
        }

        public IActionResult UserList()
        {
            var userListModel = new UserListModel();
            userListModel.Batsman = UserService.GetBatsman();
            userListModel.Bowler = UserService.GetBowlers();
            return View(userListModel);
        }

        [HttpPost]
        public void AddRanking([FromBody] List<UserPoll> userPoll)
        {
            userPoll.ForEach(userpoll =>
            {
                userpoll.UserID = CurrentUser.UserID;
                userpoll.CreatedBy = CurrentUser.UserID;
                userpoll.CreatedDate = DateTime.Now;
                userpoll.UpdatedBy = Convert.ToInt32(CurrentUser.UserID);
                userpoll.UpdatedDate = DateTime.Now;
            });
            UserService.AddOrUpdateUserPoll(userPoll);
        }
    }
}


































































