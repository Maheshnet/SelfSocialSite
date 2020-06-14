﻿using Microsoft.EntityFrameworkCore;
using SDomain;
using System;

namespace SDATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Value> Values { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                new Value { ID = 1, Name = "Value 101" },
                new Value { ID = 2, Name = "Value 102" },
                new Value { ID = 3, Name = "Value 103" },
                new Value { ID = 4, Name = "Value 104" },
                new Value { ID = 5, Name = "Value 105" }
                );
        }
    }
}