using Domain.Models;
using Domain.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping;

public class GameMatchMapping : IEntityTypeConfiguration<GameMatch>
{
    public void Configure(EntityTypeBuilder<GameMatch> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedNever();
        
        builder.HasOne(g => g.PlayerX)
            .WithMany(p => p.GameMatchesAsX)
            .HasForeignKey(g => g.PlayerXId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.PlayerO)
            .WithMany(p => p.GameMatchesAsO)
            .HasForeignKey(g => g.PlayerOId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.MovementsX).IsRequired();
        builder.Property(x => x.MovementsO).IsRequired();
        builder.Property(x => x.WinnerSide)
            .HasDefaultValue(WinnerSideEnum.DRAW)
            .IsRequired();
        
        builder.ToTable("GameMatches");
    }
}