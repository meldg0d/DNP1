using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcRepositories.EfcSetup.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Title)
            .IsRequired();
        builder.Property(x => x.Body)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .OnDelete(DeleteBehavior.Cascade);
    }
}