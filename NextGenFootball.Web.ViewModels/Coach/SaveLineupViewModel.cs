using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class SaveLineupViewModel
    {
        public int TeamId { get; set; }
        public Guid CoachId { get; set; }
        public string FormationName { get; set; }= null!; 
        public List<LineupPlayerInputModel> Players { get; set; }= new List<LineupPlayerInputModel>();
    }

   
}
