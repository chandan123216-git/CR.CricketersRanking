using CR.CricketerRanking.Type.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CR.CricketerRanking.Models
{
    public class UserListModel
    {
        public List<User> Batsman { get; set; }
        public List<User> Bowler { get; set; }
    }
}
