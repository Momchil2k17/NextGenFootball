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
    public class Player
    {
        public Guid Id { get; set; }

        public Guid? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string? PhoneNumber { get; set; }


        public int TeamId { get; set; }
        public virtual Team Team { get; set; }= null!;


        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }= null!;


        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; } = null!;

        public PositionEnum PositionEnum { get; set; }
        public PreferredFoot PreferredFoot { get; set; } 

        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
