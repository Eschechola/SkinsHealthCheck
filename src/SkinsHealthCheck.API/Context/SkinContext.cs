using Microsoft.EntityFrameworkCore;
using SkinsApiHealthChecksApi.Models;

namespace SkinsApiHealthChecks.Api.Context
{
    public class SkinContext : DbContext
    {
        public virtual DbSet<Skin> Skins { get; set; }

        public SkinContext(DbContextOptions<SkinContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Skin>(entity =>
            {
                entity.ToTable("Skin");

                entity.HasKey(x => x.Id);
                
                entity.Property(x => x.Id)
                    .HasColumnName("Id")
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd(); 

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("VARCHAR(150)");

                entity.Property(x => x.Float)
                    .IsRequired()
                    .HasColumnName("Float")
                    .HasColumnType("DOUBLE");

                entity.Property(x => x.Pattern)
                    .IsRequired()
                    .HasColumnName("Pattern")
                    .HasColumnType("INT");
            });
        }
    }
}
