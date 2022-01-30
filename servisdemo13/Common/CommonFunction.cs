using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using DYS.Business.BLL;
using DYS.Common.VO;
using DYS.Web.Models;

using DYS.Web.Models.GraphsModels;

namespace servisdemo13.Common
{
    public class CommonFunction : BaseModel
    {

        public static List<ProjectChartModel.ProjectTaskStatusModel> YoneticiProjeGorevDurumu(int projeId, ProjectChartModel model)
        {
            var task = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] { p => p.Aktif && p.ProjeId == projeId }).ToList();
            //List<ProjectTaskStatusModel> status = new List<ProjectTaskStatusModel>();

            var tamamlanmisGorevlerModel = task.Where(k => k.AktifBitmedi).ToList();
            double toplamGorevSayisi = task.Count;
            model.TaskStatusModel.Add(new ProjectChartModel.ProjectTaskStatusModel
            {
                TaskStatus = "Biten Görev" + '(' + tamamlanmisGorevlerModel.Count + ')',
                TaskStatusInPercent =(float) Math.Round((100 / toplamGorevSayisi) * Convert.ToDouble(tamamlanmisGorevlerModel.Count), 1),
                TaskStatusCount = task.Count
            });
            
            var tamamlanmamisGorevlerModel = task.Where(k => k.AktifBitmedi == false).ToList();

            model.TaskStatusModel.Add(new ProjectChartModel.ProjectTaskStatusModel
            {
                TaskStatusInPercent =(float) Math.Round((100 / toplamGorevSayisi) * Convert.ToDouble(tamamlanmamisGorevlerModel.Count), 1),
                TaskStatus = "Devam Eden Görev" + '(' + tamamlanmamisGorevlerModel.Count + ')'
            });

            return model.TaskStatusModel;
        }

        public static List<ProjectChartModel.ManagerProjectDaysModel> YoneticiProjeGunleri(int userId, ProjectChartModel model)
        {
            var projectList = ProjeBLL.Select(new Expression<Func<Proje, bool>>[] { p => p.Aktif && p.YoneticiKullaniciId == userId })
                .ToList();
            if (projectList.Count != 0)
            {
               /* DateTime a = projectList[0].SistemBaslamaTarihi;//some datetime
                DateTime now = DateTime.Now;
                TimeSpan ts = now - a;
                int days = Math.Abs(ts.Days);*/
                foreach (var project in projectList)
                {
                    TimeSpan projectDaysCount = (TimeSpan) (project.BitisTarihi - project.BaslangicTarihi);
                    model.ManagerProjectDays.Add(new ProjectChartModel.ManagerProjectDaysModel
                    {
                        ProjectName = project.ProjeAdi,
                        ProjectDaysCount =Math.Abs(projectDaysCount.Days)
                    });

                }

                //var task = GorevBLL.Select(new Expression<Func<Gorev, bool>>[] {p => p.Aktif && p.ProjeId == ProjeId})
            }
            return model.ManagerProjectDays;
        }

        public static List<ProjectChartModel.UserAssignedTaskStatusModel> UserTaskStatus(int userId, ProjectChartModel model)
        {
            //sana atanmış toplam görevleri bulalım
            var assignedTask = degerlendirmeDurumuBLL.Select(new Expression<Func<DegerlendirmeDurumu, bool>>[] { p => p.Aktif && p.Gorev.Aktif && p.KullaniciId == userId }).ToList();
            double toplamBanaAtananGorevSayisi = assignedTask.Count;


            var tamamlanmisGorevler = assignedTask.Where(k => k.Gorev.AktifBitmedi).ToList();

            model.UserAssignedTaskStatus.Add(new ProjectChartModel.UserAssignedTaskStatusModel
            {
                UserTaskStatus = "Biten Görev" + '(' + tamamlanmisGorevler.Count + ')',
                UserTaskStatusInPercent =(float) Math.Round((100 / toplamBanaAtananGorevSayisi) * tamamlanmisGorevler.Count, 1),
                UserTaskCount = assignedTask.Count
            });


            var tamamlanmayanGorevler = assignedTask.Where(k => k.Gorev.AktifBitmedi == false).ToList();

            model.UserAssignedTaskStatus.Add(new ProjectChartModel.UserAssignedTaskStatusModel
            {
                UserTaskStatus = "Devam Eden Görev" + '(' + tamamlanmayanGorevler.Count + ')',
                UserTaskStatusInPercent =(float) Math.Round((100 / toplamBanaAtananGorevSayisi) * tamamlanmayanGorevler.Count, 1),
            });
            return model.UserAssignedTaskStatus;
        }
    }
}