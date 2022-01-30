using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    [DataContract]
    public class MyTaskModel
    {
        [DataMember]

        public int TaskId { get; set; }
        [DataMember]

        public string ProjectName { get; set; }
        [DataMember]

        public string TaskName { get; set; }
        [DataMember]

        public DateTime StartDate { get; set; }
        [DataMember]

        public DateTime EndDate { get; set; }
        [DataMember]

        public Boolean? IsNow { get; set; } //şuansa true gelecek ise false geçmiş ise null
        [DataMember]

        public string StartDateStr { get; set; }
        [DataMember]

        public string EndDateStr { get; set; }
        [DataMember]
        public bool isTaskDone { get; set; }
        [DataMember]

        public MyTaskDetailModel MyTaskDetail { get; set;}

        public MyTaskModel()
        {
            MyTaskDetail = new MyTaskDetailModel();
        }
        public class MyTaskDetailModel
        {
          //  public int TaskDetailId { get; set; }
            public string TaskDetail { get; set; }
            public string SystemStartDate { get; set; }
            public string ByUserName { get; set; }

        }
        

        public class MyTaskDetailStatusModel
        {
            public Boolean IsTaskStatu { get; set; }
        }
    }
}