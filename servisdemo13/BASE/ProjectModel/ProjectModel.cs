using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace servisdemo13.BASE.ProjectModel
{
    [Serializable]
    [DataContract]
    public class ProjectModel
    {
        [DataMember]
        public int? ProjectId { get; set; }
        [DataMember]
        public string ProjectTitle { get; set; }
        [DataMember]
        public string ProjectDetail { get; set; }
        [DataMember]
        public string ProjectStartDate { get; set; }
        [DataMember]
        public string ProjectEndDate { get; set; }
        [DataMember]
        public int ManagerUserId { get; set; }
        public List<TaskModel> Task { get; set; }

        public List<SearchManagementModel> SearchManagementList { get; set; }

        public ProjectModel()
        {
            Task = new List<TaskModel>();
            SearchManagementList = new List<SearchManagementModel>();
        }

        public class TaskModel
        {
            public int TaskId { get; set; }
            public string TaskTitle { get; set; }
        }

        public class SearchManagementModel
        {
            public string Name { get; set; }
            public int TypeId { get; set; } // 1 ise proje , 2 ise görev 
            public string TaskAppointedUserMail { get; set; }
            public bool? TaskState { get; set; }
            public string StartEndDate { get; set; }
        }
    }
}