using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    public class DegerlendirmeDurumModel
    {
        List<DegerlendirmeDurumModel> degerlendirmeDurum { get; set; }
        DegerlendirmeDurumModel()
        {
            degerlendirmeDurum = new List<DegerlendirmeDurumModel>();
        }
    }
}