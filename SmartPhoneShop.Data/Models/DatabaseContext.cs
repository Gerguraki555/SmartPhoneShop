// <copyright file="DatabaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SmartPhoneShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DatabaseContext class, inhreits DbContext class. This class controlling the Database.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Gets or sets set Brands objects from Database.
        /// </summary>
        public virtual DbSet<Brands> Brands { get; set; }

        /// <summary>
        /// Gets or sets set Parameters objects from Database.
        /// </summary>
        public virtual DbSet<Parameters> Parameters { get; set; }

        /// <summary>
        /// Gets or sets set Types objects from Database.
        /// </summary>
        public virtual DbSet<Types> Types { get; set; }

        /// <summary>
        /// This method configuring the Database.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// OnmodelCreating method. This method using ModelBuilder.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*  builder.Entity<Types>(entity =>
              {
              entity.HasMany(x => x.BrandId)
                  .WithMany()
              });*/
        }
    }
}
