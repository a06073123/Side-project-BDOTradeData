using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace bdo3.Models
{
    public partial class BDOContext : DbContext
    {
        public BDOContext()
        {
        }

        public BDOContext(DbContextOptions<BDOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DailyRecord> DailyRecords { get; set; }
        public virtual DbSet<TradeItem> TradeItems { get; set; }
        public virtual DbSet<TradeRecord> TradeRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<DailyRecord>(entity =>
            {
                entity.HasKey(e => new { e.MainKey, e.Date })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("daily_record");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<TradeItem>(entity =>
            {
                entity.HasKey(e => e.MainKey)
                    .HasName("PRIMARY");

                entity.ToTable("trade_item");

                entity.Property(e => e.MainKey).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TradeRecord>(entity =>
            {
                entity.HasKey(e => new { e.Time, e.MainKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("trade_record");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
