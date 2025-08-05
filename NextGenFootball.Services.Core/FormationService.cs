using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class FormationService : IFormationService
    {
        public List<FormationViewModel> GetFormationsForCoach()
        {
            return new List<FormationViewModel>
        {
            new FormationViewModel
            {
                Name = "4-3-3",
                DisplayName = "4-3-3 (Classic)",
                Positions = new List<FormationPosition>
                {
                    new FormationPosition { PositionName = "GK", DisplayLabel = "Goalkeeper", X = 50, Y = 95 },
                    new FormationPosition { PositionName = "LB", DisplayLabel = "Left Back", X = 15, Y = 80 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 35, Y = 78 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 65, Y = 78 },
                    new FormationPosition { PositionName = "RB", DisplayLabel = "Right Back", X = 85, Y = 80 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 30, Y = 60 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 50, Y = 58 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 70, Y = 60 },
                    new FormationPosition { PositionName = "LW", DisplayLabel = "Left Wing", X = 20, Y = 35 },
                    new FormationPosition { PositionName = "CF", DisplayLabel = "Center Forward", X = 50, Y = 20 },
                    new FormationPosition { PositionName = "RW", DisplayLabel = "Right Wing", X = 80, Y = 35 },
                }
            },
            new FormationViewModel
            {
                Name = "4-2-3-1",
                DisplayName = "4-2-3-1",
                Positions = new List<FormationPosition>
                {
                    new FormationPosition { PositionName = "GK", DisplayLabel = "Goalkeeper", X = 50, Y = 95 },
                    new FormationPosition { PositionName = "LB", DisplayLabel = "Left Back", X = 15, Y = 80 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 35, Y = 78 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 65, Y = 78 },
                    new FormationPosition { PositionName = "RB", DisplayLabel = "Right Back", X = 85, Y = 80 },
                    new FormationPosition { PositionName = "CDM", DisplayLabel = "Defensive Midfield", X = 38, Y = 63 },
                    new FormationPosition { PositionName = "CDM", DisplayLabel = "Defensive Midfield", X = 62, Y = 63 },
                    new FormationPosition { PositionName = "CAM", DisplayLabel = "Attacking Midfield", X = 50, Y = 47 },
                    new FormationPosition { PositionName = "LW", DisplayLabel = "Left Wing", X = 20, Y = 35 },
                    new FormationPosition { PositionName = "RW", DisplayLabel = "Right Wing", X = 80, Y = 35 },
                    new FormationPosition { PositionName = "ST", DisplayLabel = "Striker", X = 50, Y = 20 },
                }
            }
        };
        }
    }
}
