using CR.CricketerRanking.Data.Contract;
using CR.CricketerRanking.Data.Implement;
using CR.CricketerRanking.Service.Contract;
using CR.CricketerRanking.Type.HelperType;
using CR.CricketerRanking.Type.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CR.CricketerRanking.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        public UserService()
        {
            UserRepository = new UserRepository();
        }

        public void AddOrUpdateUserPoll(List<UserPoll> userPolls)
        {
            UserRepository.AddOrUpdateUserPoll( userPolls);
        }

        public void AddUser(User user)
        {
            UserRepository.AddUser(user);
        }

        public User authenticateUser(string Username, string password)
        {
              return UserRepository.authenticateUser( Username, password);
        }

        public List<User> GetBatsman()
        {
            return UserRepository.GetBatsman();
        }

        public List<User> GetBowlers()
        {
            return UserRepository.GetBowlers();          
        }

        List<CricktersPoll> IUserService.GetUserPoll()
        {
            return UserRepository.GetUserPoll();
        }
    }
}

