using System;
using System.Text;
using System.Web.Script.Serialization;
//using System.Web.Mvc;
using DYS.Business.BLL;
using DYS.Common.VO;
using DYS.Data.Data;
//using servisdemo13..Common;

namespace DYS.Web
{
  //  [HandleError(View = "AppError")]
    public class BaseController
    {
        #region Enums
        protected enum EnumMessageType
        {
            information = 0,
            warning = 1,
            error = 2,
            question = 3,
            confirmation = 4
        }
        #endregion

   /*     #region Message Methods

        protected JsonResult MessageJson(
    string message,
    EnumMessageType type = EnumMessageType.information,
    string title = null)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Message must not be null.");
            //if (type == EnumMessageType.error)
            //{
            //    Task.Run(() => LoggerFactory.GetDbLogger().Error(message));
            //}
            if (string.IsNullOrWhiteSpace(title))
                title = string.Empty;

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    message = message.Trim(),
                    type = type.ToString(),
                    title = title.Trim(),
                    isSuccess = type == EnumMessageType.information
                }
            };
        }


        protected JsonResult MessageJson(
           string message,
           EnumMessageType type = EnumMessageType.information,
           string title = null, string filePath = null)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Message must not be null.");

            if (string.IsNullOrWhiteSpace(title))
                title = string.Empty;

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    message = message.Trim(),
                    type = type.ToString(),
                    title = title.Trim(),
                    filepath = filePath.Trim(),
                    isSuccess = type == EnumMessageType.information
                }
            };
        }

        protected ContentResult MessageScript(
    string message,
    EnumMessageType type = EnumMessageType.information,
    string title = null)
        {
            var result = GetMessageScript(message, type, title);
            return Content(result);
        }

        */
        private string GetMessageScript(
    string message,
    EnumMessageType type = EnumMessageType.information,
    string title = null)
        {
            // Validate arguments.
            if (message == null)
                throw new ArgumentNullException("message", "Message must not be null.");

            // Initialize `<script>` block.
            var jsBuilder = new StringBuilder("<script>toastr.");
            switch (type)
            {
                case EnumMessageType.information:
                    jsBuilder.Append("info");
                    break;
                case EnumMessageType.warning:
                    jsBuilder.Append("warning");
                    break;
                case EnumMessageType.error:
                    jsBuilder.Append("error");
                    break;
                default:
                    goto case EnumMessageType.warning;
            }

            if (!string.IsNullOrWhiteSpace(title))
                jsBuilder.AppendFormat("('{0}', '{1}')", message, title);
            else
                jsBuilder.AppendFormat("('{0}')", message);

            jsBuilder.Append("</script>");
            return jsBuilder.ToString();
        }

        //#endregion

        private ModelContext _modelContext;

        protected ModelContext ModelContext
        {
            get
            {

                return _modelContext ?? (_modelContext = new ModelContext());
            }
        }
 

        #region FieldProje
        protected ProjeBLL<Proje> ProjeBLL
        {
            get
            {
                return new ProjeBLL<Proje>();
            }
        }
        #endregion

        #region FieldsKullanici
        protected KullaniciBLL<Kullanici> KullaniciBLL
        {
            get
            {
                return new KullaniciBLL<Kullanici>();
            }
        }
        #endregion

        #region FieldsRol
        protected RolBLL<Rol> RolBLL
        {
            get
            {
                return new RolBLL<Rol>();
            }
        }
        #endregion

        #region FieldsSayfaAltYetkiler
        protected SayfaAltYetkilerBLL<SayfaAltYetkiler> SayfaAltYetkilerBLL
        {
            get
            {
                return new SayfaAltYetkilerBLL<SayfaAltYetkiler>();
            }
        }
        #endregion

        #region FieldsSayfaIslemler
        protected SayfaIslemlerBLL<SayfaIslemler> SayfaIslemlerBLL
        {
            get
            {
                return new SayfaIslemlerBLL<SayfaIslemler>();
            }
        }
        #endregion

        #region FieldsSayfalar
        protected SayfalarBLL<Sayfalar> SayfalarBLL
        {
            get
            {
                return new SayfalarBLL<Sayfalar>();
            }
        }
        #endregion

        #region FieldsSayfaYetkiler
        protected SayfaYetkilerBLL<SayfaYetkiler> SayfaYetkilerBLL
        {
            get
            {
                return new SayfaYetkilerBLL<SayfaYetkiler>();
            }
        }
        #endregion

        #region FieldsGorev

        protected GorevBLL<Gorev> GorevBLL
        {
            get
            {
                return new GorevBLL<Gorev>();
            }
        }
        

        #endregion

        #region FieldsAltGorev
        protected AltGorevBLL<AltGorev> AltGorevBLL
        {
            get
            {
                return new AltGorevBLL<AltGorev>();
            }
        }
        #endregion



        #region FieldsDegerlendirmeDurumu
        protected DegerlendirmeDurumuBLL<DegerlendirmeDurumu> DegerlendirmeDurumuBLL
        {
            get
            {
                return new DegerlendirmeDurumuBLL<DegerlendirmeDurumu>();
            }
        }
        #endregion


        #region FieldsDokumanGorev
        protected DokumanGorevBLL<DokumanGorev> DokumanGorevBLL
        {
            get
            {
                return new DokumanGorevBLL<DokumanGorev>();
            }
        }
        #endregion



        #region FieldsDokumanProje
        protected DokumanProjeBLL<DokumanProje> DokumanProjeBLL
        {
            get
            {
                return new DokumanProjeBLL<DokumanProje>();
            }
        }
        #endregion



        #region FieldsMesaj
        protected MesajBLL<Mesaj> MesajBLL
        {
            get
            {
                return new MesajBLL<Mesaj>();
            }
        }
        #endregion

        #region FieldsUserFriend

        protected UserFriendBLL<UserFriend> UserFriendBLL
        {
            get
            {
                return new UserFriendBLL<UserFriend>();
            }
        }

        #endregion

        #region FieldProjectMessage
        protected ProjectMessageBLL<ProjectMessage> ProjectMessageBLL
        {
            get
            {
                return new ProjectMessageBLL<ProjectMessage>();
            }
        }

        #endregion
        #region FieldFolderManagement
        protected FolderManagementBLL<FolderManagement> FolderManagementBLL
        {
            get
            {
                return new FolderManagementBLL<FolderManagement>();
            }
        }

        #endregion
        #region FieldFileManagement
        protected FileManagementBLL<FileManagement> FileManagementBLL
        {
            get
            {
                return new FileManagementBLL<FileManagement>();
            }
        }

        #endregion

     /*   public int GetUserId()
        {
            if (Session["KullaniciId"] != null)
            {
                return Convert.ToInt32(Session["KullaniciId"]);
            }
            return 0;
        }*/
      /*  public int GetQueryStringId(string Id)
        {

            if (!string.IsNullOrEmpty(Id))
            {
                try
                {
                    return Convert.ToInt32(CryptorEngine.Decrypt(Id, true));
                }
                catch (Exception)
                {
                    return Convert.ToInt32(Id);
                }
            }

            return 0;
        }*/
        internal string GetJsonData(dynamic content)
        {
            string jsonData = string.Empty;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonData = serializer.Serialize(content);
            return jsonData;
        }

         
    }
}