﻿using Microsoft.EntityFrameworkCore;
using WorldApi.Models;

namespace WorldApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Country> Countries { get; set; } 
    }
}
