using ChalanaChithram.CastService.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChalanaChithram.CastService.Api.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.ProfileImageUrl)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.InstagramUrl).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.TwitterUrl).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.FacebookUrl).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.YoutubeUrl).HasMaxLength(500).IsRequired(false);

        builder.HasMany(x => x.MovieCredits)
            .WithOne(x => x.Person!)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
