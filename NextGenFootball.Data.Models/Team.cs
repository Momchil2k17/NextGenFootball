using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a football team.")]
    public class Team
    {
        [Comment("Unique identifier for the team.")]
        public int Id { get; set; }
        [Comment("Name of the team, e.g., 'CSKA Sofia'.")]
        public string Name { get; set; } = null!;
        [Comment("Region of the team, e.g., 'Североизточна България'.")]
        public Region Region { get; set; }
        [Comment("Age group of the league, e.g., 'U19'.")]
        public string AgeGroup { get; set; } = null!;
        [Comment("URL of the team's image.")]
        public string? ImageUrl { get; set; }
        [Comment("Description of the team.")]
        public string? Description { get; set; }

        [Comment("Unique identifier for the stadium where the team plays.")]
        public int StadiumId { get; set; }
        public virtual Stadium Stadium { get; set; }= null!;

        [Comment("Unique identifier for the league in which the team participates.")]
        public int LeagueId { get; set; }
        public virtual League League { get; set; } = null!;

        [Comment("Soft delete flag indicating if the team is deleted.")]

        public bool IsDeleted { get; set; }

        [Comment("Collection of players in the team.")]
        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public virtual ICollection<Coach> Coaches { get; set; } = new HashSet<Coach>();
    }
}
