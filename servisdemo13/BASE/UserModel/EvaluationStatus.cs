using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    public class EvaluationStatus
    {
        public String UserId { get; set; }
        public String NominatorUserId { get; set; }
        public String ProjectId { get; set; }
        public String TaskId { get; set; }
        public Boolean ToBeAppoint { get; set; }


    }
}