using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class CoachLineupViewModel
    {
        public IEnumerable<PlayerForCoachSquad> Players { get; set; } = new List<PlayerForCoachSquad>();
        public List<FormationViewModel> Formations { get; set; } = new();
        public string SelectedFormationName { get; set; } = "4-3-3";
        public List<Guid> SelectedPlayers { get; set; } = new();
        public List<string> SelectedPositions { get; set; } = new();

        public int TeamId { get; set; }
        public Guid CoachId { get; set; }
    }
    public class FormationViewModel
    {
        public string Name { get; set; } = null!; // e.g. "4-3-3"
        public string DisplayName { get; set; } = null!; // e.g. "4-3-3 (Classic)"
        public List<FormationPosition> Positions { get; set; } = new();
    }

    public class FormationPosition
    {
        public string PositionName { get; set; } = null!; // e.g. "GK", "LB", "CB", etc.
        public string DisplayLabel { get; set; } = null!;
        public int X { get; set; } // grid/fraction for JS rendering
        public int Y { get; set; }
    }
}
