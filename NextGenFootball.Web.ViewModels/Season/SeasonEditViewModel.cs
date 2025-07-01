using NextGenFootball.Data.Common.EntityConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.SeasonValidationConstants;

namespace NextGenFootball.Web.ViewModels.Season
{
    public class SeasonEditViewModel:SeasonCreateViewModel
    {
        public int Id { get; set; }
    }
}
