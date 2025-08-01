using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeAssignments
{
    public class AssignRefereeViewModel
    {
        public int LeagueId { get; set; }
        public long MatchId { get; set; }
        public string HomeTeam { get; set; } = null!;
        public string AwayTeam { get; set; } = null!;
        public string? HomeTeamImageUrl { get; set; }
        public string? AwayTeamImageUrl { get; set; }
        public DateTime Date { get; set; }
        public List<FreeRefereeModel>? AvailableReferees { get; set; }
        public Guid? MainRefereeId { get; set; }
        public Guid? AssistantReferee1Id { get; set; }
        public Guid? AssistantReferee2Id { get; set; }
    }
}
