﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
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
                entity.Property(e => e.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
            });
            modelBuilder.Entity<ProfileImageEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });
        }
    }
}