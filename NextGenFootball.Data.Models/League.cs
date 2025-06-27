using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a football league.")]
    public class League
    {
        [Comment("Unique identifier for the league.")]
        public int Id { get; set; }
        [Comment("Name of the league, e.g., 'A PFG'.")]
        public string Name { get; set; } = null!;
        [Comment("Region of the league, e.g., 'Североизточна България'.")]
        public Region Region { get; set; } 
        [Comment("Age group of the league, e.g., 'U19'.")]
        public string AgeGroup { get; set; }= null!; 
        [Comment("Description of the league.")]
        public string? Description { get; set; }
        [Comment("URL of the league's image.")]
        public string? ImageUrl { get; set; }
        [Comment("Corresponging season of the league.")]
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }=null!;
        [Comment("Soft delete")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of teams that participate in this league.")]
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
