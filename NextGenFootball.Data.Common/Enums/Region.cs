using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.Enums
{
    public enum Region
    {
        [Display(Name = "Североизточна България")]
        СевероизточнаБългария = 1,

        [Display(Name = "Северозападна България")]
        СеверозападнаБългария = 2,

        [Display(Name = "Югозападна България")]
        ЮгозападнаБългария = 3,

        [Display(Name = "Югоизточна България")]
        ЮгоизточнаБългария = 4
    }
}
