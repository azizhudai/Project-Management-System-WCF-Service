using System.ComponentModel;

namespace DYS.Common.VO
{
    public class Enums
    {
        public enum RolTuru
        {
            [Description("Sistem Yöneticisi")]
            Admin = 1,
            [Description("Kullanıcı")]
            User = 2
        }

        public enum GorevDurumu
        {
            [Description("Yüksek")]
            Yüksek = 1,
            [Description("Düşük")]
            Düşük = 2
        }

        public enum Aylar
        {
            [Description("Ocak")]
            Ocak = 1,
            [Description("Şubat")]
            Subat = 2,
            [Description("Mart")]
            Mart = 3,
            [Description("Nisan")]
            Nisan = 4,
            [Description("Mayıs")]
            Mayis = 5,
            [Description("Haziran")]
            Haziran = 6,
            [Description("Temmuz")]
            Temmuz = 7,
            [Description("Ağustos")]
            Ağustos = 8,
            [Description("Eylül")]
            Eylül = 9,
            [Description("Ekim")]
            Ekim = 10,
            [Description("Kasım")]
            Kasım = 11,
            [Description("Aralık")]
            Aralık = 12

        }
    }
}
