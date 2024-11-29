using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcRepositories.EfcSetup.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Body)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}