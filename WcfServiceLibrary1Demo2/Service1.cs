using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary1Demo2.ServiceReference1;

namespace WcfServiceLibrary1Demo2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public MyTask GetGorev(MyTask MyTask)
        {
            PYS_demo db = new PYS_demo();
            var task = (from k in db.Gorev
                        where k.GorevId == MyTask.TaskId
                        select new MyTask
                        {
                            TaskId = k.GorevId,
                            TaskName = k.GorevAdi
                        }).FirstOrDefault();
            return task;
        }

        public List<MyTask> DeseriliazeMyTask(string json)
        {
            List<MyTask> deserializedUser = new List<MyTask>();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as List<MyTask>;
            ms.Close();
            return deserializedUser;
        }
        public string InsertProject(string managerId, string projectSeriliaze)
        {
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
                    //  DYS.Business.BLL.ProjeBLL.Insert(project);

                    return "OK";
                }
                else return "NULL";

            }
            catch (Exception e)
            {
                return "ERR";
            }

        }

        public string InsertProjectManuel(string managerId, string projectTitle, string projectDetail, string projectStartDate,
            string projectEndDate)
        {
            try
            {
                DateTime? myDateStart = null;
                var managerUserId = Convert.ToInt32(managerId);
                if (projectStartDate != null)
                {
                    myDateStart = DateTime.ParseExact(projectStartDate,
                        "yyyy-MM-dd", //"2009-05-08 14:40:52,531";
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                DateTime? myDateEnd = null;
                if (projectEndDate != null)
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
                //ProjeBLL.Insert(project);
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
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


    }

    [DataContract]
    public class ProjectModel
    {
        [DataMember]
        public int ProjectId { get; set; }

        [DataMember]
        public string ProjectTitle { get; set; }

        [DataMember]
        public string ProjectDetail { get; set; }

        [DataMember]
        public string ProjectStartDate { get; set; }

        [DataMember]
        public string ProjectEndDate { get; set; }

        [DataMember]
        public int? ManagerUserId { get; set; }

    }

    [DataContract]
    public class MyTask
    {
        [DataMember]
        public int TaskId { get; set; }
        [DataMember]
        public string TaskName { get; set; }
    }
    [DataContract]
    [Serializable]
    public class StatusModel
    {
        [DataMember]

        public Boolean? IsSuccess { get; set; }
    }

}
