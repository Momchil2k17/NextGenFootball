using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> entity)
        {
            entity
                .HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(s => s.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            entity
                .Property(s => s.Capacity)
                .IsRequired();

            entity
                .Property(s => s.Surface)
                .IsRequired();

            entity
                .Property(s => s.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(s => s.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(s => s.IsDeleted == false);
        }
    }
}
