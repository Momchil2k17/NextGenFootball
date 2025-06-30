using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerStatsEditViewModel
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Range(0, int.MaxValue)]
        public int Goals { get; set; }

        [Range(0, int.MaxValue)]
        public int Assists { get; set; }

        [Range(0, int.MaxValue)]
        public int MinutesPlayed { get; set; }

        [Range(0, int.MaxValue)]
        public int YellowCards { get; set; }

        [Range(0, int.MaxValue)]
        public int RedCards { get; set; }
    }
}
