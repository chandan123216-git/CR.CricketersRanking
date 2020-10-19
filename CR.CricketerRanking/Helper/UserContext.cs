using CR.CricketerRanking.Type.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR.CricketerRanking.Helper
{
    public class UserContext
    {
        private static User CurrentUser { get; set; }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static User GetUser()
        {
            return CurrentUser;
        }
    }

    
}
