using ChalanaChithram.CastService.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChalanaChithram.CastService.Api.Data.Configurations;

public class MovieCreditConfiguration : IEntityTypeConfiguration<MovieCredit>
{
    public void Configure(EntityTypeBuilder<MovieCredit> builder)
    {
        builder.ToTable("MovieCredits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.MovieId)
            .IsRequired();

        builder.Property(x => x.PersonId)
            .IsRequired();

        builder.Property(x => x.Role)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.CharacterName)
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.Order)
            .IsRequired();

        builder.HasIndex(x => new { x.MovieId, x.Role });
    }
}
