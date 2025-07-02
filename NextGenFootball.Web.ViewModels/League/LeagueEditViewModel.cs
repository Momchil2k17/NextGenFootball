using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.LeagueValidationConstants;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueEditViewModel : LeagueCreateViewModel
    {
        public int Id { get; set; }
    }
}
