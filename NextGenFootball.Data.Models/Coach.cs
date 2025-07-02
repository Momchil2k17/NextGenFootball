using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a football coach.")]
    public class Coach
    {
        [Comment("Unique identifier for the coach.")]
        public Guid Id { get; set; }

        [Comment("Unique identifier for the application user associated with the coach.")]
        public Guid? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Comment("First name of the coach.")]
        public string FirstName { get; set; } = null!;
        [Comment("Last name of the coach.")]
        public string LastName { get; set; } = null!;

        [Comment("Role of the coach, e.g., 'Head Coach', 'Assistant Coach'.")]
        public CoachRole Role { get; set; }

        [Comment("Phone number of the coach.")]
        public string? PhoneNumber { get; set; }


        [Comment("Unique identifier for the team that the coach manages.")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; } = null!;

        [Comment("Image of the coach")]
        public string? ImageUrl { get; set; }

        [Comment("Soft delete flag indicating if the coach is deleted.")]
        public bool IsDeleted { get; set; }
    }
}
