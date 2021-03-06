using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using DYS.Web;
using DYS.Common.VO;
using DYS.Data.Data;
using DYS.Web.Models.GraphsModels;
using servisdemo13.BASE;
using servisdemo13.BASE.ProjectModel;
using servisdemo13.BASE.UserModel;
using servisdemo13.Common;
using System.Web.Services;

namespace servisdemo13
{
    //[ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class Service1 : BaseController, IService1
    {

        /*   [OperationContract]
           [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
               RequestFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Bare)]*/


        public List<Kullanici> GetUser()
        {
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]

        public string GetTask()
        {
            var taskList = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] { p => p.Aktif }).OrderByDescending(k=>k.GorevBaslangic).ToList();
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //   string json = jss.Serialize(taskList);

            return GetJsonData(taskList);
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetGorevOne/{id}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetGorevOne(string id)
        {
            int taskId = Convert.ToInt32(id);
            var task = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] { p => p.Aktif && p.GorevId == taskId }).FirstOrDefault();
            return GetJsonData(task);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [WebMethod]
        public List<ProjectModel> GetProTask()
        {
            ModelContext mc = new ModelContext();
            var project = (from k in mc.Projes
                           where k.Aktif
                           select new ProjectModel
                           {
                               ProjectId = k.ProjeId,
                               ProjectTitle = k.ProjeAdi,
                               ProjectStartDate = k.BaslangicTarihi.ToString(),
                               ProjectEndDate = k.BitisTarihi.ToString(),
                               Task = k.Gorevs.Where(f => f.Aktif).Select(item => new ProjectModel.TaskModel
                               {
                                   TaskId = item.GorevId,
                                   TaskTitle = item.GorevAdi
                               }).ToList()
                           }).ToList();
            return project;
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ProjectModel.TaskModel> GetTaskList()
        {
            ModelContext mc = new ModelContext();
            var taskList = (from k in mc.Gorevs
                            where k.Aktif
                            select new ProjectModel.TaskModel
                            {
                                TaskId = k.GorevId,
                                TaskTitle = k.GorevAdi
                            }).ToList();
            return taskList;
        }


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "DeleteTask/{userId}/{taskId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string DeleteTask(string userId, string taskId)
        {
            try
            {
                var tid = Convert.ToInt32(taskId);
                var task = GorevBLL.SelectWithId(tid);
                task.Aktif = false;
                GorevBLL.Update(task.GorevId, task);

                return "Görev Silinme Başarılı";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /* public string AppointTask(List<DegerlendirmeDurumModel> atama)
         {
             try
             {
                 for(int i = 0;i< atama.Count; i++)
                 {
                     DegerlendirmeDurumu degerlendirme = new DegerlendirmeDurumu
                     {
                         Aktif= true,
                         AtayanKullanici = atama.
                     }
                 }

             }
             catch (Exception e)
             {

                 throw;
             }
         }*/
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json, UriTemplate = "EditTaskName/{userId}/{taskId}/{taskName}",
           BodyStyle = WebMessageBodyStyle.Bare)]
        public string EditTaskName(string userId, string taskId, string taskName)
        {
            try
            {
                var taskIdint = Convert.ToInt32(taskId);
                var task = GorevBLL.SelectWithId(taskIdint);
                if (task != null)
                {
                    task.GorevAdi = taskName;
                    GorevBLL.Update(task.GorevId, task);
                    return "Görev Adı Güncellendi.";
                }
                else return "Hata";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }
        //  @GET("login/{userEmail}/{userPassword}")

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "login/{userEmail}/{userPassword}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public UserModel Login(string userEmail, string userPassword)
        {
            try
            {
                UserModel users = new UserModel();
                var user = KullaniciBLL.Select(new Expression<Func<Kullanici, bool>>[]
                    {p => p.Aktif && p.EMail == userEmail && p.Sifre == userPassword }).FirstOrDefault();
                if (user != null)
                {
                    users.UserId = user.KullaniciId;
                    return users;
                }

                else
                {

                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //@GET("GetProject/{userId}")
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetProject/{userId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<UserProjectModel> GetProject(string userId)
        {
            List<UserProjectModel> projectModelList = new List<UserProjectModel>();
            ModelContext mc = new ModelContext();
            var userIdint = Convert.ToInt32(userId);
            var project = (from k in mc.Projes
                           where k.Aktif && k.YoneticiKullaniciId == userIdint
                           select new UserProjectModel
                           {
                               ProjectId = k.ProjeId,
                               ProjectName = k.ProjeAdi
                           }).ToList();
            projectModelList = project;
            return projectModelList;

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetUserTask/{userId}/{projectId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<MyTaskModel> GetUserTask(string userId, string projectId)
        {
            ModelContext mc = new ModelContext();
            var userIdint = Convert.ToInt32(userId);
            var projectIdint = Convert.ToInt32(projectId);
            //List<MyTaskModel> model = new List<MyTaskModel>();
            var taskList = (from k in mc.Gorevs
                            where k.Aktif && k.ProjeId == projectIdint && k.Proje.YoneticiKullaniciId == userIdint
                            select new MyTaskModel
                            {
                                TaskId = k.GorevId,
                                TaskName = k.GorevAdi,
                                StartDate = k.GorevBaslangic,
                                EndDate = k.GorevBitis,
                                IsNow = k.GorevBitis > DateTime.Now ? false : true,
                                isTaskDone = k.AktifBitmedi
                            }).OrderByDescending(k => k.StartDate).ToList();
            //taskList = taskList.OrderByDescending(k => k.StartDate);
            var dateStartStr = new List<string>();
            var dateEndStr = new List<string>();
            for (int i = 0; i < taskList.Count; i++)
            {
                dateStartStr.Add(taskList[i].StartDate.ToString("dd/MM/yyyy"));
                taskList[i].StartDateStr = dateStartStr[i];

                dateEndStr.Add(taskList[i].EndDate.ToString("dd/MM/yyyy"));
                taskList[i].EndDateStr = dateEndStr[i];

                var faasa = DateTime.Now.Date;
                if (taskList[i].StartDate <= DateTime.Now && taskList[i].EndDate >= DateTime.Now.Date) //yani şuanki tarihler içierinde isem true
                {
                    taskList[i].IsNow = true;
                }
                else if (taskList[i].StartDate < DateTime.Now) // geçmiş bir görevdir.
                {
                    taskList[i].IsNow = null;
                }
                else if (taskList[i].EndDate > DateTime.Now)
                {
                    taskList[i].IsNow = false;
                }

            }
            //model = taskList;
            return taskList;
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json, UriTemplate = "GetMyTask/{userId}",
           BodyStyle = WebMessageBodyStyle.Bare)]
        public List<MyTaskModel> GetMyTask(string userId)
        {
            var userIdint = Convert.ToInt32(userId);
            ModelContext mc = new ModelContext();
            var myTask = (from k in mc.DegerlendirmeDurumus
                          where k.Aktif == true && k.KullaniciId == userIdint && k.Gorev.AktifBitmedi == false
                          select new MyTaskModel
                          {
                              TaskId = k.GorevId,
                              ProjectName = k.Proje.ProjeAdi,
                              TaskName = k.Gorev.GorevAdi,
                              StartDate = k.Gorev.GorevBaslangic,
                              EndDate = k.Gorev.GorevBitis,
                              IsNow = k.Gorev.GorevBitis > DateTime.Now ? false : true

                          }).OrderByDescending(k=>k.StartDate).ToList();
            var dateStartStr = new List<string>();
            var dateEndStr = new List<string>();
            for (int i = 0; i < myTask.Count; i++)
            {
                dateStartStr.Add(myTask[i].StartDate.ToString("dd/MM/yyyy"));
                myTask[i].StartDateStr = dateStartStr[i];

                dateEndStr.Add(myTask[i].EndDate.ToString("dd/MM/yyyy"));
                myTask[i].EndDateStr = dateEndStr[i];

                var faasa = DateTime.Now.Date;
                if (myTask[i].StartDate <= DateTime.Now && myTask[i].EndDate >= DateTime.Now.Date) //yani şuanki tarihler içierinde isem true
                {
                    myTask[i].IsNow = true;
                }
                else if (myTask[i].StartDate < DateTime.Now) // geçmiş bir görevdir.
                {
                    myTask[i].IsNow = null;
                }
                else if (myTask[i].EndDate > DateTime.Now)
                {
                    myTask[i].IsNow = false;
                }

            }
            return myTask;

        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetTaskDetail/{userId}/{taskId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public MyTaskModel.MyTaskDetailModel GetTaskDetail(string userId, string taskId)
        {
            var userIdint = Convert.ToInt32(userId);
            var taskIdint = Convert.ToInt32(taskId);
            ModelContext mc = new ModelContext();
            var taskDetail = (from k in mc.DegerlendirmeDurumus
                              where k.KullaniciId == userIdint && k.GorevId == taskIdint
                              select new MyTaskModel.MyTaskDetailModel
                              {
                                  // TaskDetailId = k.Id,
                                  TaskDetail = k.Gorev.GorevAciklama,
                                  SystemStartDate = k.Gorev.SistemBaslamaTarihi.ToString(),
                                  ByUserName = k.AtayanKullanici.EMail
                              }).FirstOrDefault();
            return taskDetail;
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetProjectTaskDetail/{userId}/{taskId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public MyTaskModel.MyTaskDetailModel GetProjectTaskDetail(string userId, string taskId)
        {
            var userIdint = Convert.ToInt32(userId);
            var taskIdint = Convert.ToInt32(taskId);
            ModelContext mc = new ModelContext();
            var task = (from k in mc.Gorevs
                        where k.Aktif && k.GorevId == taskIdint
                        select new MyTaskModel.MyTaskDetailModel
                        {
                            TaskDetail = k.GorevAciklama,
                            SystemStartDate = k.SistemBaslamaTarihi.ToString(),
                            ByUserName = k.Kullanici.EMail
                        }).FirstOrDefault();
            return task;
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetUserFriend/{userId}/{taskId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<UserFriendModel> GetUserFriend(string userId, string taskId)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId); var taskIdint = Convert.ToInt32(taskId);
                ModelContext mc = new ModelContext();
                var friend = (from k in mc.UserFriends
                              where k.Aktive && k.UserId == userIdint
                              select new UserFriendModel
                              {
                                  UserId = k.UserJobFriendId,
                                  UserMail = k.Kullanici2.EMail,
                                  IsAppoint = (from t in mc.DegerlendirmeDurumus where t.Aktif && t.KullaniciId == k.UserJobFriendId && t.GorevId == taskIdint select t.Aktif).FirstOrDefault() //!= null ? true : false 
                              }).ToList();
                return friend;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetUserAppointedTaskList/{userId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<UserAppointedTask> GetUserAppointedTaskList(string userId) // tüm atamış oldumuz görevleri listyek
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                ModelContext mc = new ModelContext();
                var allAppointTaskList = (from k in mc.DegerlendirmeDurumus
                                          where k.Aktif && k.AtayanKullaniciId == userIdint
                                          select new UserAppointedTask
                                          {
                                              AppointedId = k.Id,
                                              UserId = k.KullaniciId,
                                              UserMail = k.Kullanici.EMail,
                                              TaskId = k.GorevId,
                                              ProjectId = k.ProjeId,
                                              TaskName = k.Gorev.GorevAdi,
                                              ProjectName = k.Proje.ProjeAdi,
                                              Score = k.Puan,
                                              IsDone = k.Gorev.AktifBitmedi,
                                              TaskStartDateTime = k.Gorev.GorevBaslangic,
                                              TaskEndDateTime = k.Gorev.GorevBitis,
                                              ResidulaPercentageValue = 0

                                              //  IsScoring = (from t in mc.DegerlendirmeDurumus where t.Aktif && t.KullaniciId == k.UserJobFriendId && t.Puan != null select t.Aktif).FirstOrDefault() //!= null ? true : false 
                                          }).ToList();
                foreach (var value in allAppointTaskList)
                {
                    if (value.IsDone == false)
                    {
                        double kalanGunSayisi;
                        double toplamGunSayisi = Convert.ToDouble((value.TaskEndDateTime - value.TaskStartDateTime).TotalDays);
                        if ((DateTime.Now - value.TaskStartDateTime).TotalDays > 0)
                            kalanGunSayisi = Convert.ToDouble((value.TaskEndDateTime - DateTime.Now).TotalDays);

                        else kalanGunSayisi = Convert.ToDouble((value.TaskEndDateTime - value.TaskStartDateTime).TotalDays);
                        //toplam 10 gün diyelim kalan gün sayısı 4 ise 4/10dan 40 / 100
                        value.ResidulaPercentageValue = Math.Ceiling(100 - ((kalanGunSayisi / toplamGunSayisi) * 100));
                        value.ResidualTotalDays = kalanGunSayisi.ToString("0.##") + "/" + toplamGunSayisi;
                    }



                }

                return allAppointTaskList;
            }
            catch (Exception e)
            {
                return new List<UserAppointedTask>();
            }
        }
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "SetUserScoring",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string SetUserScoring(UserScoringModel userScore)
        {
            try
            {
                var appointedTask = DegerlendirmeDurumuBLL.SelectWithId(userScore.AppointedId);
                appointedTask.AtayanKullaniciId = userScore.UserById;
                appointedTask.KullaniciId = userScore.UserId;
                appointedTask.Puan = userScore.Score;
                DegerlendirmeDurumuBLL.Update(appointedTask.Id, appointedTask);
                return "Puan Verme Başarılı";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        /*[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetProjectTaskAppointUser/{userId}/{taskId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<BASE.UserModel.UserFriendModel> GetProjectTaskAppointUser(string userId, string taskId)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                var taskIdint = Convert.ToInt32(taskId);
                ModelContext mc = new ModelContext();
                var taskAppoint = (from k in mc.DegerlendirmeDurumus
                    where k.Aktif && k.GorevId == taskIdint
                    select new BASE.UserModel.UserFriendModel
                    {
                        UserId = k.KullaniciId,
                        UserMail = k.Kullanici.EMail
                    }).ToList();
                return taskAppoint;
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }*/


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "EditProjectTaskStartDate/{userId}/{taskId}/{taskStartDate}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string EditProjectTaskStartDate(string userId, string taskId, string taskStartDate)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                var taskIdint = Convert.ToInt32(taskId);

                DateTime taskDateStart;
                if (taskStartDate != null)
                {
                    taskDateStart = DateTime.ParseExact(taskStartDate,
                        "yyyy.MM.dd", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                    var task = GorevBLL.SelectWithId(taskIdint);
                    task.GorevBaslangic = taskDateStart;
                    GorevBLL.Update(task.GorevId, task);

                    return "OK";
                }
                return "NO";

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "EditProjectTaskEndDate/{userId}/{taskId}/{taskEndDate}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string EditProjectTaskEndDate(string userId, string taskId, string taskEndDate)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                var taskIdint = Convert.ToInt32(taskId);

                DateTime taskDateEnd;
                if (taskEndDate != null)
                {
                    taskDateEnd = DateTime.ParseExact(taskEndDate,
                        "yyyy.MM.dd", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                    var task = GorevBLL.SelectWithId(taskIdint);
                    task.GorevBitis = taskDateEnd;
                    GorevBLL.Update(task.GorevId, task);
                    return "OK";
                }
                return "NO";

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "SetTaskStatus/{taskId}/{isTaskStatu}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public MyTaskModel.MyTaskDetailStatusModel SetTaskStatus(string taskId, string isTaskStatu)
        {
            try
            {
                bool statu = false;
                if (isTaskStatu == "1") statu = true; else statu = false;
                //  var userIdint = Convert.ToInt32(userId);
                var taskIdint = Convert.ToInt32(taskId);
                var task = GorevBLL.SelectWithId(taskIdint);

                task.AktifBitmedi = statu;
                GorevBLL.Update(task.GorevId, task);
                MyTaskModel.MyTaskDetailStatusModel model = new MyTaskModel.MyTaskDetailStatusModel();
                model.IsTaskStatu = statu;
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

            /* ModelContext mc = new ModelContext();
             var task = (from k in mc.DegerlendirmeDurumus
                 where k.KullaniciId == userIdint && k.GorevId == taskIdint
                 select new MyTaskModel.MyTaskDetailStatusModel
                 {
                     IsTaskStatu = k.Gorev.AktifBitmedi
                 }).FirstOrDefault();*/


        }
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertProjectClass",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string InsertProjectClass(ProjectModel projectModel)
        {
            //StatusModel statu = new StatusModel();

            try
            {
                //  var managerUserId = Convert.ToInt32(managerId);

                /*  ProjectModel deserializedProject = new ProjectModel();
                  MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(projectSeriliaze));
                  DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedProject.GetType());
                  deserializedProject = ser.ReadObject(ms) as ProjectModel;
                  ms.Close();*/
                if (projectModel != null)
                {
                    DateTime myDateStart = DateTime.ParseExact(projectModel.ProjectStartDate,
                        "dd.MM.yyyy", //"2009-05-08 14:40:52,531"; //"yyyy - MM - dd
                        System.Globalization.CultureInfo.InvariantCulture);
                    DateTime myDateEnd = DateTime.ParseExact(projectModel.ProjectEndDate,
                        "dd.MM.yyyy", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                    var project = new Proje
                    {
                        Aktif = true,
                        AktifBitmedi = true,
                        YoneticiKullaniciId = projectModel.ManagerUserId,
                        ProjeAdi = projectModel.ProjectTitle,
                        ProjeAciklama = projectModel.ProjectDetail,
                        BaslangicTarihi = myDateStart,
                        BitisTarihi = myDateEnd,
                        SistemBaslamaTarihi = DateTime.Now,
                        Sira = 1,
                        GizlilikAktif = false
                    };
                    ProjeBLL.Insert(project);

                    // statu.IsSuccess = true;
                    return "Proje Ekleme Başarılı";
                }
                else
                {
                    //statu.IsSuccess = false;
                    return "Hatalı";
                }

            }
            catch (Exception e)
            {
                //statu.IsSuccess = null;
                return e.Message;
            }

        }


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertProject/{managerId}/{projectSeriliaze}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public StatusModel InsertProject(string managerId, string projectSeriliaze)
        {
            StatusModel statu = new StatusModel();

            try
            {
                var managerUserId = Convert.ToInt32(managerId);
                ProjectModel deserializedProject = new ProjectModel();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(projectSeriliaze));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedProject.GetType());
                deserializedProject = ser.ReadObject(ms) as ProjectModel;
                ms.Close();
                if (deserializedProject != null)
                {
                    DateTime myDateStart = DateTime.ParseExact(deserializedProject.ProjectStartDate,
                        "yyyy-MM-dd", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                    DateTime myDateEnd = DateTime.ParseExact(deserializedProject.ProjectEndDate,
                        "yyyy-MM-dd", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                    var project = new Proje
                    {
                        Aktif = true,
                        AktifBitmedi = true,
                        YoneticiKullaniciId = managerUserId,
                        ProjeAdi = deserializedProject.ProjectTitle,
                        ProjeAciklama = deserializedProject.ProjectDetail,
                        BaslangicTarihi = myDateStart,
                        BitisTarihi = myDateEnd,
                        SistemBaslamaTarihi = DateTime.Now,
                        Sira = 1,
                        GizlilikAktif = false
                    };
                    ProjeBLL.Insert(project);

                    statu.IsSuccess = true;
                    return statu;
                }
                else
                {
                    statu.IsSuccess = false;
                    return statu;
                }

            }
            catch (Exception e)
            {
                statu.IsSuccess = null;
                return statu;
            }

        }



        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertProject/{managerId}/{projectTitle}/{projectDetail}/{projectStartDate}/{projectEndDate}",
            BodyStyle = WebMessageBodyStyle.Bare)]

        public string InsertProjectManuel(string managerId, string projectTitle, string projectDetail, string projectStartDate,
            string projectEndDate)
        {
            try
            {
                DateTime? myDateStart = null;
                var managerUserId = Convert.ToInt32(managerId);
                if (projectStartDate != "")
                {
                    myDateStart = DateTime.ParseExact(projectStartDate,
                       "yyyy-MM-dd", //"2009-05-08 14:40:52,531";
                       System.Globalization.CultureInfo.InvariantCulture);
                }
                DateTime? myDateEnd = null;
                if (projectEndDate != "")
                {
                    myDateEnd = DateTime.ParseExact(projectEndDate,
                       "yyyy-MM-dd", //"2009-05-08 14:40:52,531";
                       System.Globalization.CultureInfo.InvariantCulture);
                }

                var project = new Proje
                {
                    Aktif = true,
                    AktifBitmedi = true,
                    YoneticiKullaniciId = managerUserId,
                    ProjeAdi = projectTitle,
                    ProjeAciklama = projectDetail,
                    BaslangicTarihi = myDateStart,
                    BitisTarihi = myDateEnd,
                    SistemBaslamaTarihi = DateTime.Now,
                    Sira = 1,
                    GizlilikAktif = false
                };
                ProjeBLL.Insert(project);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "DenemeSeri/{seri}",
            BodyStyle = WebMessageBodyStyle.Bare)]

        public StatusModel DenemeSeri(string seri)
        {
            try
            {
                StatusModel deserializedProject = new StatusModel();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(seri));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedProject.GetType());
                deserializedProject = ser.ReadObject(ms) as StatusModel;
                ms.Close();
                return deserializedProject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "DeseriliazeMyTask/{json}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<MyTaskModel> DeseriliazeMyTask(string json)
        {
            List<MyTaskModel> deserializedUser = new List<MyTaskModel>();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as List<MyTaskModel>;
            ms.Close();
            return deserializedUser;
        }



        /*  [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
              RequestFormat = WebMessageFormat.Json, UriTemplate = "UserAccount/kullanici",
              BodyStyle = WebMessageBodyStyle.Bare)]
          public string UserAccount(Kullanici kullanici)
          {
              try
              {
                  var user = KullaniciBLL.Select(new Expression<Func<DYS.Common.VO.Kullanici, bool>>[]
                      {p => p.Aktif && p.EMail == kullanici.EMail && p.Sifre == kullanici.Sifre}).FirstOrDefault();
                  if (user != null)
                      return "OK";
                  else return "NO";
              }
              catch (Exception e)
              {
                  return e.Message;
              }
          }*/

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "UserTaskStatus/{userId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ProjectChartModel.UserAssignedTaskStatusModel> UserTaskStatus(string userId)
        {
            try
            {
                var model = new ProjectChartModel();
                var userIdint = Convert.ToInt32(userId);
                var userTaskStatus = CommonFunction.UserTaskStatus(userIdint, model);
                return userTaskStatus;
            }
            catch (Exception e)
            {
                return null;
            }


        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "ManagerProjectTaskStatus/{userId}/{projectId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ProjectChartModel.ProjectTaskStatusModel> ManagerProjectTaskStatus(string userId, string projectId)
        {
            try
            {
                var model = new ProjectChartModel();
                var userIdint = Convert.ToInt32(userId);
                var projectIdint = Convert.ToInt32(projectId);
                var projectTaskStatu = CommonFunction.YoneticiProjeGorevDurumu(projectIdint, model);
                return projectTaskStatu;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json, UriTemplate = "ManagerProjectDays/{userId}",
           BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ProjectChartModel.ManagerProjectDaysModel> ManagerProjectDays(string userId)
        {
            try
            {
                var model = new ProjectChartModel();
                var userIdint = Convert.ToInt32(userId);
                var managerProjectDays = CommonFunction.YoneticiProjeGunleri(userIdint, model);
                return managerProjectDays;
            }
            catch (Exception e)
            {

                return null;
            }
        }


        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "UpdateTokenId",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string UpdateTokenId(UserTokenModel userToken)
        {
            try
            {
                var userIdint = Convert.ToInt32(userToken.UserId);
                var user = KullaniciBLL.SelectWithId(userIdint);
                user.TokenId = userToken.TokenId;
                KullaniciBLL.Update(user.KullaniciId, user);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "RemoveTokenId/{userId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string RemoveTokenId(string userId)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                var user = KullaniciBLL.SelectWithId(userIdint);
                user.TokenId = "0";
                KullaniciBLL.Update(user.KullaniciId, user);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "GetUserTokenId/{userId}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public GetUserTokenModel GetUserTokenId(string userId)
        {
            try
            {
                var userIdint = Convert.ToInt32(userId);
                var user = KullaniciBLL.SelectWithId(userIdint);
                GetUserTokenModel userToken = new GetUserTokenModel();
                userToken.UserId = user.KullaniciId.ToString();
                userToken.TokenId = user.TokenId;
                return userToken;
            }
            catch (Exception e)
            {
                GetUserTokenModel userToken = new GetUserTokenModel();
                userToken.UserId = "0";
                userToken.TokenId = "0";
                return userToken;
            }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, UriTemplate = "PostAppointUserList",
            BodyStyle = WebMessageBodyStyle.Bare)]
        public string PostAppointUserList(List<EvaluationStatus> evaluationStatusList)
        {
            try
            {
                if (evaluationStatusList != null && evaluationStatusList.Count != 0)
                {
                    ModelContext mc = new ModelContext();
                    var taskIdint = Convert.ToInt32(evaluationStatusList[0].TaskId);
                    /* var degerlendirme = DegerlendirmeDurumuBLL.Select(new Expression<Func<DegerlendirmeDurumu, bool>>[]
                         { p=> p.Aktif && p.GorevId == taskIdint}).ToList();
                    */
                    foreach (var evaluationStatus in evaluationStatusList) //silme işlemi tekrardan eklemeyelim.. 7 eleman var 3 ü atanmış idi yani degerlendirmede vardı
                    {
                        int userIdAtayan = Convert.ToInt32(evaluationStatus.NominatorUserId);
                        int projectId = Convert.ToInt32(evaluationStatus.ProjectId);

                        int userId = Convert.ToInt32(evaluationStatus.UserId);
                        int taskId = Convert.ToInt32(evaluationStatus.TaskId);
                        var degerlendirme = DegerlendirmeDurumuBLL.Select(
                            new Expression<Func<DegerlendirmeDurumu, bool>>[]
                            {
                                k => k.KullaniciId == userId && k.GorevId == taskId
                            }).FirstOrDefault();
                        if (degerlendirme != null && degerlendirme.Aktif != evaluationStatus.ToBeAppoint)
                        {
                            degerlendirme.Aktif = evaluationStatus.ToBeAppoint;
                            DegerlendirmeDurumuBLL.Update(degerlendirme.Id, degerlendirme);
                        }

                        if (degerlendirme == null && evaluationStatus.ToBeAppoint == true) //yani ilk defa atama yapılack ise bu göreve;
                        {
                            DegerlendirmeDurumu degerlendirmeDurumu = new DegerlendirmeDurumu
                            {
                                Aktif = evaluationStatus.ToBeAppoint,
                                AtayanKullaniciId = userIdAtayan,
                                GorevId = taskId,
                                IlerlemeDurumAdi = null,
                                Puan = 0,
                                ProjeId = projectId,
                                KullaniciId = userId


                            };
                            DegerlendirmeDurumuBLL.Insert(degerlendirmeDurumu);
                        }
                    }

                    return "OK";
                }
                else return "ERR";
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }

        //proje sayısı, görev sayısı,

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json, UriTemplate = "GetTotalCountProjectDetail/{userId}",
       BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetTotalCountProjectDetail(string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var userIdValue = Convert.ToInt32(userId);
                    var projectManagementCount = ProjeBLL.Select(new Expression<Func<Proje, bool>>[] { p => p.Aktif == true && p.YoneticiKullaniciId == userIdValue }).Count();//yönetilen proje sayısı

                    var taskManagementList = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] { p => p.Proje.Aktif == true && p.Aktif == true && p.Proje.YoneticiKullaniciId == userIdValue });//.ToList();

                    var taskManagementCount = taskManagementList.Count();//yöneticisi olunan görev sayısı
                    //var doneTaskCount = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] { p => p.Proje.Aktif == true && p.Aktif == true && p.Proje.YoneticiKullaniciId == userIdValue }).Count();
                    var doneTaskCount = taskManagementList.Where(p => p.AktifBitmedi == true).Count();//biten görevler
                    var goingTaskCont = taskManagementList.Where(p => p.AktifBitmedi == false).Count();//devam eden görevler
                    var today = DateTime.Now;
                    var overdueTaskCount = taskManagementList.Where(p => p.AktifBitmedi == false && p.GorevBitis <= today).Count(); //bitmemiş ve süresi geçmişler
                    var totaalCountList = projectManagementCount.ToString() + "," + taskManagementCount.ToString() + "," + doneTaskCount.ToString() + "," + goingTaskCont.ToString() + "," + overdueTaskCount;
                    return totaalCountList;

                }
                else
                {
                    return "Tekrar Giriş yapınız!";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
     RequestFormat = WebMessageFormat.Json, UriTemplate = "GetSearchManagement/{userId}/{searchStrig}",
     BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ProjectModel.SearchManagementModel> GetSearchManagement(string userId, string searchStrig)
        {
            var searchList = new List<ProjectModel.SearchManagementModel>();
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var userIdValue = Convert.ToInt32(userId);
                    ModelContext mc = new ModelContext();
                    var projectList = (from k in mc.Projes
                                       where k.Aktif == true && k.YoneticiKullaniciId == userIdValue && k.ProjeAdi.ToLower().Contains(searchStrig.ToLower())
                                       orderby k.ProjeId descending
                                       select new ProjectModel.SearchManagementModel
                                       {
                                           Name = k.ProjeAdi,
                                           StartEndDate = k.BaslangicTarihi.ToString() + " - " + k.BitisTarihi.ToString(),
                                           TaskAppointedUserMail = "",
                                           TypeId = 1
                                       }).ToList();

                    var taskList = (from k in mc.Gorevs
                                    where k.Proje.Aktif == true && k.Aktif == true && k.Proje.YoneticiKullaniciId == userIdValue && k.GorevAdi.ToLower().Contains(searchStrig.ToLower())
                                    orderby k.GorevId descending
                                    select new ProjectModel.SearchManagementModel {
                                        Name = k.GorevAdi,
                                        StartEndDate = k.GorevBaslangic.ToString() + " - " + k.GorevBitis.ToString(),
                                        TaskState = k.AktifBitmedi,
                                        TypeId = 2
                                    }).ToList();

                    searchList = projectList.Union(taskList).ToList();

                    return searchList;
                }
                else
                {
                    searchList.Add(new ProjectModel.SearchManagementModel { TypeId = 3, Name = "Tekrar Giriş yapınız!" });
                    return searchList;
                }

            }
            catch (Exception e)
            {
                searchList.Add(new ProjectModel.SearchManagementModel { TypeId = 3, Name = e.Message });
                return searchList;

            }
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
     RequestFormat = WebMessageFormat.Json, UriTemplate = "GetTaskPointAnalize/{userId}",
     BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetTaskPointAnalize(string userId) // bana verilen puanların hesabı
        {
            try
            {
                var userIdValue = Convert.ToInt32(userId);
                var taskPoint = DegerlendirmeDurumuBLL.Select(new Expression<Func<DegerlendirmeDurumu, bool>>[] { p => p.Aktif == true && p.KullaniciId == userIdValue }).ToList();
                var fivePoint = taskPoint.Where(p => p.Puan == 5.0).Count();
                var fourPoint = taskPoint.Where(p => p.Puan == 4.0).Count();
                var threePoint = taskPoint.Where(p => p.Puan == 3.0).Count();
                var twoPoint = taskPoint.Where(p => p.Puan == 2.0).Count();
                var onePoint = taskPoint.Where(p => p.Puan == 1.0).Count();

                var totalPoint = fivePoint * 5 + fourPoint * 4 + threePoint * 3 + twoPoint * 2 + onePoint * 1;
                string avarage = String.Format("{0:f2}", (double)totalPoint / ((double)fivePoint + fourPoint + threePoint + twoPoint + onePoint)); //ortalama

                string totalSurvey = (fivePoint + fourPoint + threePoint + twoPoint + onePoint).ToString();

                var strDetailPoint = fivePoint.ToString() +
                    ',' + fourPoint.ToString() +
                    ',' + threePoint.ToString() +
                    ',' + twoPoint.ToString() +
                    ',' + onePoint.ToString() +
                    ',' + totalPoint.ToString() +
                    ',' + totalSurvey.ToString() +
                    ',' + avarage.ToString().Replace(',', '.');

                return strDetailPoint;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        //benim verdiğim puanları filtere olarak aratabilelim

        //
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
     RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertUserInf",
     BodyStyle = WebMessageBodyStyle.Bare)]
        public string InsertUserInf(InsertUserModel user) // bana verilen puanların hesabı
        {
            try
            {

                var checkUserExist = KullaniciBLL.Select(new Expression<Func<Kullanici, bool>>[]
                    {p => p.Aktif && p.EMail == user.UserMail }).FirstOrDefault();
                if (checkUserExist != null)
                {
                    return "-1"; // böyle bir mail tanımlı dedik.
                }
                else if (checkUserExist == null)
                {
                    Kullanici kullanici = new Kullanici
                    {
                        EMail = user.UserMail,
                        Ad = user.UserName,
                        Soyad = user.UserSurname,
                        Sifre = user.Password,
                        Aktif = true,
                        RoleId = 17,
                        TokenId = "0",

                    };
                    KullaniciBLL.Insert(kullanici);
                    return "1";
                }
                else return "0";


            }
            catch (Exception e)
            {

                return "0";
            }



        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json, UriTemplate = "InsertTaskClass",
           BodyStyle = WebMessageBodyStyle.Bare)]
        public string InsertTaskClass(InsertTaskModel taskModel) // bana verilen puanların hesabı
        {
            try
            {
                DateTime myDateStart = DateTime.ParseExact(taskModel.TaskStartDate,
                            "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);//yyyy-MM-dd
                DateTime myDateEnd = DateTime.ParseExact(taskModel.TaskEndDate,
                    "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Gorev tasks = new Gorev
                {
                    Aktif = true,
                    AktifBitmedi = false,
                    GizlilikAktif = false,
                    GorevAdi = taskModel.TaskName,
                    GorevAciklama = taskModel.TaskDetail,
                    ProjeId = taskModel.ProjectId,
                    Sira = 1,
                    SistemBaslamaTarihi = DateTime.Now,
                    GorevBaslangic = myDateStart,
                    GorevBitis = myDateEnd,
                    KullaniciId = taskModel.UserId

                };
                GorevBLL.Insert(tasks);
                return "1";

            }
            catch (Exception e)
            {

                return e.Message;
            }
        }



    }

    //
      
        


}
