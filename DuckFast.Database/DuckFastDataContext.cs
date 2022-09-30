﻿using DuckFast.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckFast.Database
{
    public class DuckFastDataContext : DbContext
    {
        public DbSet<Article>? Articles { get; set; }
        public DbSet<UserAccount>? UserAccounts { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DuckFastDataContext(): base() { }

        public DuckFastDataContext(DbContextOptions<DuckFastDataContext> options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=db;Database=duckfast_data;Username=postgres;Password=postgres");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=duckfast_data;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().Property(x => x.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Category>().Property(x => x.Id).UseIdentityAlwaysColumn();
        }
    }
}
