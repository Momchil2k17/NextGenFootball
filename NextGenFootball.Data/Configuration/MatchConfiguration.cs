using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using static NextGenFootball.Data.Common.EntityConstants.MatchValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> entity)
        {
            entity.
                HasKey(m => m.Id);

            entity
                .Property(m => m.Date)
                .IsRequired();

            entity
                .Property(m => m.HomeScore)
                .IsRequired(false);

            entity
                .Property(m => m.AwayScore)
                .IsRequired(false);

            entity
                .Property(m => m.VideoUrl)
                .IsRequired(false)
                .HasMaxLength(VideoUrlMaxLength);

            entity
                .Property(m => m.Status)
                .IsRequired();

            entity
                .Property(m => m.IsDeleted)
                .HasDefaultValue(false);


            entity
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.Stadium)
                .WithMany(s => s.Matches)
                .HasForeignKey(m => m.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.League)
                .WithMany(l=>l.Matches)
                .HasForeignKey(m => m.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);
            entity
                .HasOne(m => m.Referee)
                .WithMany(r => r.MainRefereeMatches)
                .HasForeignKey(m => m.RefereeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.AssistantReferee1)
                .WithMany(r => r.AssistantReferee1Matches)
                .HasForeignKey(m => m.AssistantReferee1Id)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(m => m.AssistantReferee2)
                .WithMany(r => r.AssistantReferee2Matches)
                .HasForeignKey(m => m.AssistantReferee2Id)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(m => m.Round)
                .IsRequired();

            entity
                .HasQueryFilter(m => m.IsDeleted == false);
            entity
                .HasData(this.SeedMatches());
        }
        public IEnumerable<Match> SeedMatches()
        {
            var today = new DateTime(2025, 8, 6);
            List<Match> matches = new List<Match>
            {
               new Match { Id = 1, HomeTeamId = 1, AwayTeamId = 2, StadiumId = 1, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 1, Date = today.AddDays(6).AddHours(14) },
    new Match { Id = 2, HomeTeamId = 3, AwayTeamId = 4, StadiumId = 3, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 1, Date = today.AddDays(6).AddHours(15) },
    new Match { Id = 3, HomeTeamId = 5, AwayTeamId = 6, StadiumId = 5, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 1, Date = today.AddDays(6).AddHours(16) },
    new Match { Id = 4, HomeTeamId = 7, AwayTeamId = 8, StadiumId = 7, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 1, Date = today.AddDays(6).AddHours(17) },
    new Match { Id = 5, HomeTeamId = 9, AwayTeamId = 10, StadiumId = 9, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 1, Date = today.AddDays(6).AddHours(18) },

    // Round 2
    new Match { Id = 6, HomeTeamId = 2, AwayTeamId = 3, StadiumId = 2, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 2, Date = today.AddDays(7).AddHours(14) },
    new Match { Id = 7, HomeTeamId = 4, AwayTeamId = 5, StadiumId = 4, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 2, Date = today.AddDays(7).AddHours(15) },
    new Match { Id = 8, HomeTeamId = 6, AwayTeamId = 7, StadiumId = 6, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 2, Date = today.AddDays(7).AddHours(16) },
    new Match { Id = 9, HomeTeamId = 8, AwayTeamId = 9, StadiumId = 8, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 2, Date = today.AddDays(7).AddHours(17) },
    new Match { Id = 10, HomeTeamId = 10, AwayTeamId = 1, StadiumId = 10, LeagueId = 1, Status = MatchStatus.Scheduled, Round = 2, Date = today.AddDays(7).AddHours(18) }
            };
            return matches;
        }
    }
}
