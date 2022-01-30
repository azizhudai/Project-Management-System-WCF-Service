using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    public class UserAppointedTask
    {
        public int AppointedId { get; set; }
        public int UserId { get; set; }
        public string UserMail { get; set; }
        public int? ProjectId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public double? Score { get; set; }
        public bool IsDone { get; set; }
        public Double ResidulaPercentageValue { get; set; }
        public DateTime TaskStartDateTime { get; set; }
        public DateTime TaskEndDateTime { get; set; }
        public string ResidualTotalDays { get; set; }
    }
}