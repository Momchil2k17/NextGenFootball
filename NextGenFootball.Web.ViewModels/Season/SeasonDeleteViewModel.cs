using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Season
{
    public class SeasonDeleteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
