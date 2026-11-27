using Masrwof.Components.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; } 
        public DbSet<Category> Categories { get; set; }

    }
}
