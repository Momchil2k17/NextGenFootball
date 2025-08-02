using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using static NextGenFootball.Data.Common.EntityConstants.NewsValidationConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Configuration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> entity)
        {
            entity
                .HasKey(n=> n.Id);

            entity
                .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(ContentMaxLength);

            entity
                .Property(n => n.Author)
                .IsRequired()
                .HasMaxLength(AuthorMaxLength);

            entity
                .Property(n => n.PublishedOn)
                .IsRequired();

            entity
                .Property(n => n.ImageUrl)
                .IsRequired(false) 
                .HasMaxLength(ImageUrlMaxLength);

        }
    }
}
