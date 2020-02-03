using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMashService.DataAccess
{
    public partial class CatMashDBContext : DbContext
    {
        public CatMashDBContext()
        {
        }

        public CatMashDBContext(DbContextOptions<CatMashDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCat> TCat { get; set; }
        public virtual DbSet<TMatche> TMatche { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCat>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__T_Cat__6A1C8AFAA6F02431");

                entity.ToTable("T_Cat");

                entity.Property(e => e.CatUrl)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMatche>(entity =>
            {
                entity.HasKey(e => e.MatcheId)
                    .HasName("PK__T_Matche__5CD355D1C416106A");

                entity.ToTable("T_Matche");

                entity.Property(e => e.MatchResult)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.LeftCat)
                    .WithMany(p => p.TMatcheLeftCat)
                    .HasForeignKey(d => d.LeftCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_WonMatches_CatId");

                entity.HasOne(d => d.RightCat)
                    .WithMany(p => p.TMatcheRightCat)
                    .HasForeignKey(d => d.RightCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_LostMatches_CatId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
