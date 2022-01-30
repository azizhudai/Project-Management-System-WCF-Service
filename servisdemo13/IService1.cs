using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using DYS.Common.VO;
using DYS.Web.Models.GraphsModels;
using servisdemo13.BASE;
using servisdemo13.BASE.ProjectModel;
using servisdemo13.BASE.UserModel;

namespace servisdemo13
{

    [ServiceContract(Namespace= "")]
    interface IService1
    {
        [OperationContract]
       // [WebGet]

        List<Kullanici> GetUser();

        [OperationContract]
        string GetTask();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetGorevOne/{id}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        string GetGorevOne(string id);

        [OperationContract]
        List<ProjectModel> GetProTask();

        [OperationContract]
        List<ProjectModel.TaskModel> GetTaskList();

       
        [OperationContract]
        string DeleteTask(string userId ,string taskId);

        /*    [OperationContract]
            [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json, UriTemplate = "kullanici",
                BodyStyle = WebMessageBodyStyle.Bare)]
            string UserAccount(Kullanici kullanici);*/

            [OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "login/{userEmail}/{userPassword}")]
            UserModel Login(string userEmail, string userPassword);

        [OperationContract]
        List<UserProjectModel> GetProject(string userId);

        [OperationContract]
        List<MyTaskModel> GetUserTask(string userId, string projectId);

        [OperationContract]
        List<MyTaskModel> GetMyTask(string userId);

        [OperationContract]
        MyTaskModel.MyTaskDetailModel GetTaskDetail(string userId, string taskId);

       
        [OperationContract]
        MyTaskModel.MyTaskDetailStatusModel SetTaskStatus(string taskId, string isTaskStatu);

        [OperationContract]
        List<MyTaskModel> DeseriliazeMyTask(string json);

        [OperationContract]
        StatusModel InsertProject(string managerId, string projectSeriliaze);

        [OperationContract]
        StatusModel DenemeSeri(string seri);

        [OperationContract]
        string InsertProjectClass( ProjectModel projectModel);

        [OperationContract]
        string InsertProjectManuel(string managerId, string projectTitle, string projectDetail, string projectStartDate,
            string projectEndDate);

        [OperationContract]
        string EditProjectTaskStartDate(string userId, string taskId, string taskStartDate);

        [OperationContract]
        string EditProjectTaskEndDate(string userId, string taskId, string taskEndDate);

        [OperationContract]
        MyTaskModel.MyTaskDetailModel GetProjectTaskDetail(string userId, string taskId);

        //[OperationContract]
      //  List<UserFriendModel> GetProjectTaskAppointUser(string userId, string taskId);

        [OperationContract]
        List<UserFriendModel> GetUserFriend(string userId, string taskId);

        [OperationContract]
        string EditTaskName(string userId, string taskId, string taskName);

        [OperationContract]
        List<ProjectChartModel.UserAssignedTaskStatusModel> UserTaskStatus(string userId);

        [OperationContract]
        List<ProjectChartModel.ProjectTaskStatusModel> ManagerProjectTaskStatus(string userId, string projectId);
        [OperationContract]
        List<ProjectChartModel.ManagerProjectDaysModel> ManagerProjectDays(string userId);

        [OperationContract]
        string UpdateTokenId(UserTokenModel userToken);

        [OperationContract]
        string RemoveTokenId(string userId);
        [OperationContract]
        GetUserTokenModel GetUserTokenId(string userId);

        [OperationContract]
        string PostAppointUserList(List<EvaluationStatus> evaluationStatusList);

        [OperationContract]
        List<UserAppointedTask> GetUserAppointedTaskList(string userId);

        [OperationContract]
        string SetUserScoring(UserScoringModel userScore);
        [OperationContract]
        string GetTotalCountProjectDetail(string userId);

        [OperationContract]
        List<ProjectModel.SearchManagementModel> GetSearchManagement(string userId, string searchStrig);
        [OperationContract]
        string GetTaskPointAnalize(string userId);

        //

        [OperationContract]
        string InsertUserInf(InsertUserModel user);
        [OperationContract]
        string InsertTaskClass(InsertTaskModel task);

    }

}
