using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data.Entities;

namespace RandomUserApi.Data
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<ProfileImageEntity> ProfileImageEntities { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<ProfileImageEntity>()
                    .WithOne(e => e.User)
                    .IsRequired();
            });
            modelBuilder.Entity<ProfileImageEntity>(entity => { entity.HasKey(e => e.Id); });
        }
    }
}