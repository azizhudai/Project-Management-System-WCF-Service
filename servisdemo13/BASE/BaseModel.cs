using DYS.Business.BLL;
using DYS.Common.VO;
using DYS.Data.Data;


namespace DYS.Web.Models
{
    public class BaseModel
    {
        private static ModelContext _modelContext;

        protected static ModelContext ModelContext
        {
            get
            {
                return _modelContext ?? (_modelContext = new ModelContext());
            }
        }

        #region FieldsKullanici
        protected static KullaniciBLL<Kullanici> KullaniciBLL
        {
            get
            {
                return new KullaniciBLL<Kullanici>();
            }
        }
        #endregion

        #region FieldsRol
        protected static RolBLL<Rol> RolBLL
        {
            get
            {
                return new RolBLL<Rol>();
            }
        }

        protected static ProjeBLL<Proje> ProjeBLL
        {
            get
            {
                return new ProjeBLL<Proje>();
            }
        }
        #endregion

        #region FieldsSayfaAltYetkiler
        protected static SayfaAltYetkilerBLL<SayfaAltYetkiler> SayfaAltYetkilerBLL
        {
            get
            {
                return new SayfaAltYetkilerBLL<SayfaAltYetkiler>();
            }
        }
        #endregion

        #region FieldsSayfaIslemler
        protected static SayfaIslemlerBLL<SayfaIslemler> SayfaIslemlerBLL
        {
            get
            {
                return new SayfaIslemlerBLL<SayfaIslemler>();
            }
        }
        #endregion

        #region FieldsSayfalar
        protected static SayfalarBLL<Sayfalar> SayfalarBLL
        {
            get
            {
                return new SayfalarBLL<Sayfalar>();
            }
        }
        #endregion

        #region FieldsSayfaYetkiler
        protected static SayfaYetkilerBLL<SayfaYetkiler> SayfaYetkilerBLL
        {
            get
            {
                return new SayfaYetkilerBLL<SayfaYetkiler>();
            }
        }
        #endregion

        #region FieldsGorevler

        protected static GorevBLL<Gorev> GorevBLL
        {
            get
            {
                return new GorevBLL<Gorev>();
            }
        }

        #endregion

        protected static DegerlendirmeDurumuBLL<DegerlendirmeDurumu> degerlendirmeDurumuBLL
        {
            get
            {
                return new DegerlendirmeDurumuBLL<DegerlendirmeDurumu>();
            }
        }

        protected static MesajBLL<Mesaj> MesajBLL
        {
            get
            {
                return new MesajBLL<Mesaj>();
            }
        }
    }
}