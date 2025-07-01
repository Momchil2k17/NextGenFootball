using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationConstants;

namespace NextGenFootball.Web.ViewModels.Stadium
{
    public class StadiumEditViewModel : StadiumCreateViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
