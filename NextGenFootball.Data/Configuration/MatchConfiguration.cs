using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .HasQueryFilter(m => m.IsDeleted == false);
        }
    }
}
