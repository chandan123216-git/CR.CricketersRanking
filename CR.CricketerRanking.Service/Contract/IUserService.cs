using CR.CricketerRanking.Type.HelperType;
using CR.CricketerRanking.Type.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CR.CricketerRanking.Service.Contract
{
    public interface IUserService
    {
        List<User> GetBatsman();
        List<User> GetBowlers();
        void AddOrUpdateUserPoll(List<UserPoll> userPolls);
        List<CricktersPoll> GetUserPoll();
        void AddUser(User user);
        User authenticateUser(string Username, string password);
    }
}