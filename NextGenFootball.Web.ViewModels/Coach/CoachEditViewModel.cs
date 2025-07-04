using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class CoachEditViewModel : CoachCreateViewModel
    {
        public Guid Id { get; set; }
        public Guid? ApplicationUserId { get; set; }

    }
}
