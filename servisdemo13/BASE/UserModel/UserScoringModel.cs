using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    public class UserScoringModel
    {
        public int AppointedId { get; set; }
        public int UserById { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
       // public int? TaskId { get; set; }
       // public int? ProjectId { get; set; } 
    }
}