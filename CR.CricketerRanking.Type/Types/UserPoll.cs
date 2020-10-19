using System;
using System.Collections.Generic;
using System.Text;

namespace CR.CricketerRanking.Type.Types
{
    public class UserPoll
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PlayerID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

