using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.PlayerValidationConstants;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerEditViewModel : PlayerCreateViewModel
    {
        public Guid Id { get; set; }

        public Guid? ApplicationUserId { get; set; }
       
    }

}
