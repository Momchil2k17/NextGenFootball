using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a football match between two teams.")]
    public class Match
    {
        [Comment("Primary key for the match.")]
        public long Id { get; set; }

        [Comment("The ID of the home team.")]
        public int HomeTeamId { get; set; }

        [Comment("The home team participating in the match.")]
        public virtual Team HomeTeam { get; set; } = null!;

        [Comment("The ID of the away team.")]
        public int AwayTeamId { get; set; }

        [Comment("The away team participating in the match.")]
        public virtual Team AwayTeam { get; set; } = null!;

        [Comment("The date and time when the match is scheduled.")]
        public DateTime Date { get; set; }

        [Comment("The score of the home team. Null if not played yet.")]
        public int? HomeScore { get; set; }

        [Comment("The score of the away team. Null if not played yet.")]
        public int? AwayScore { get; set; }

        [Comment("The ID of the stadium where the match is played.")]
        public int StadiumId { get; set; }

        [Comment("The stadium where the match is played.")]
        public virtual Stadium Stadium { get; set; } = null!;

        [Comment("The ID of the league to which this match belongs.")]
        public int LeagueId { get; set; }

        [Comment("The league to which this match belongs.")]
        public virtual League League { get; set; } = null!;

        [Comment("The current status of the match (e.g., Scheduled, Finished, etc.).")]
        public MatchStatus Status { get; set; }

        [Comment("Optional video URL for match highlights or full match.")]
        public string? VideoUrl { get; set; }

        [Comment("Indicates whether the match is soft-deleted.")]
        public bool IsDeleted { get; set; }

        public Guid? RefereeId { get; set; }
        public virtual Referee? Referee { get; set; }

        public Guid? AssistantReferee1Id { get; set; }
        public virtual Referee? AssistantReferee1 { get; set; }
        public Guid? AssistantReferee2Id { get; set; }
        public virtual Referee? AssistantReferee2 { get; set; }
    }
}

