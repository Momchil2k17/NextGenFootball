using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a stadium where matches are played.")]
    public class Stadium
    {
        [Comment("Unique identifier for the stadium.")]
        public int Id { get; set; }

        [Comment("Name of the stadium.")]
        public string Name { get; set; }=null!;

        [Comment("Description of the stadium")]
        public string? Description { get; set; }

        [Comment("Location address of the stadium.")]
        public string Address { get; set; } = null!;

        [Comment("Maximum amount of people that can visit the stadium.")]
        public int Capacity { get; set; }

        [Comment("Type of surface the stadium has, e.g., Grass, Artificial, Hybrid, etc.")]
        public SurfaceType Surface { get; set; }

        [Comment("Representing photo of the stadium.")]
        public string? ImageUrl { get; set; }

        [Comment("Shows if the stadium is active or not(soft delete)")]
        public bool IsDeleted { get; set; }

        [Comment("Collection of teams that play in this stadium.")]
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();

        [Comment("Collection of matches played in this stadium.")]
        public virtual ICollection<Match> Matches { get; set; } = new HashSet<Match>();
    }
}
