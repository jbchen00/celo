using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data.Entities;

namespace RandomUserApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany<ProfileImageEntity>()
                    .WithOne(e => e.User)
                    .IsRequired();
            });
            modelBuilder.Entity<ProfileImageEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}