using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a referee in the football management system.")]
    public class Referee
    {
        [Comment("Unique identifier for the referee")]
        public Guid Id { get; set; }

        [Comment("Unique identifier for the application user associated with the coach.")]
        public Guid? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Comment("First name of the referee")]
        public string FirstName { get; set; } = null!;
        [Comment("Last name of the referee")]
        public string LastName { get; set; } = null!;

        [Comment("Phone number of the referee.")]
        public string PhoneNumber { get; set; }=null!;

        [Comment("Email of the referee.")]
        public string Email { get; set; } = null!;

        [Comment("Image URL of the referee.")]
        public string? ImageUrl { get; set; }

        [Comment("Indicates whether the referee is deleted.")]
        public bool IsDeleted { get; set; } 

        public virtual ICollection<Match> MainRefereeMatches { get; set; } = new HashSet<Match>();
        public virtual ICollection<Match> AssistantReferee1Matches { get; set; } = new HashSet<Match>();
        public virtual ICollection<Match> AssistantReferee2Matches { get; set; } = new HashSet<Match>();
    }
}
