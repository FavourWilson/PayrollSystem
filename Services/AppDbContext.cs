using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee_Expenses>()
                .HasOne(b => b.Employee)
                .WithMany(ex => ex.Employee_Expenses)
                .HasForeignKey(em => em.EmployeeId);

            modelBuilder.Entity<Employee_Expenses>()
                .HasOne(b => b.Expenses)
                .WithMany(ex => ex.Employee_Expenses)
                .HasForeignKey(em => em.ExpensesId);

           
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

        public DbSet<Employee_Expenses> Employee_Expenses { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Income> incomes { get; set; }

    }
}
