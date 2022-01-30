using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DYS.Web.Models.GraphsModels
{
    public class ProjectChartModel
    {
        
        public string ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string XMount { get; set; }
        public int YProjectCount { get; set; }

        public List<ProjectTaskStatusModel> TaskStatusModel { get; set; }
        public List<UserAssignedTaskStatusModel> UserAssignedTaskStatus { get; set; }
        public List<AllTaskStatusModel> AllTaskStatus { get; set; }
        public List<ManagerProjectDaysModel> ManagerProjectDays { get; set; }
        public List<UserRatingStatusModel> UserRatingStatus { get; set; }
        public ProjectChartModel()
        {
            TaskStatusModel = new List<ProjectTaskStatusModel>();
            UserAssignedTaskStatus = new List<UserAssignedTaskStatusModel>();

            AllTaskStatus = new List<AllTaskStatusModel>();
            ManagerProjectDays = new List<ManagerProjectDaysModel>();

            UserRatingStatus = new List<UserRatingStatusModel>();

        }

        public class ProjectTaskStatusModel //her projedeki görevlerdeki durumu göstercez yani 3 görev tamamlanmadı 5 görev tamamlandı gibi
        {
            public string TaskStatus { get; set; }
            public float TaskStatusInPercent  { get; set; }
            public int TaskStatusCount { get; set; }
           /* public string TamamlanmisGörevler { get; set; }
            public int TamamlanmisGorevSayisi { get; set; }
            public string TamamlanmamisGörevler { get; set; }
            public int TamamlanmamisGorevSayisi { get; set; }*/
           // public int ProjectId { get; set; }
            //public int TaskId { get; set; }
            //public string TaskTitle { get; set; }


        }

        public class UserAssignedTaskStatusModel
        {
            public string UserTaskStatus{ get; set; }
            public float UserTaskStatusInPercent { get; set; }
            public int UserTaskCount { get; set; }
        }

        public class AllTaskStatusModel
        {
            public string AllTaskStatusName { get; set; }
            public double AllTaskStatusInPercent { get; set; }
            public int AlltaskCount { get; set; }
        }

        public class ManagerProjectDaysModel
        {
            public string ProjectName { get; set; }
            public float ProjectDaysCount { get; set; }
        }

        public class UserRatingStatusModel
        {
            public int StarsCountPercent { get; set; }
            public int StarsCount { get; set; }
            public string StarsName { get; set; }
            public double? SumStars { get; set; }
            public int? ValuedTaskCount { get; set; }
        }
    }
    
}