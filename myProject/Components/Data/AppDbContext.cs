using Microsoft.EntityFrameworkCore;
using myProject.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
