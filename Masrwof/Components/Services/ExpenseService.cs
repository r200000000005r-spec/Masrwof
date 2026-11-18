using Masrwof.Components.Data;
using Masrwof.Components.Interfaces;
using Masrwof.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Components.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly AppDbContext c;
        public ExpenseService(AppDbContext con)
        {
            c = con;
        }
        public void InitializeDatabase()
        {
            c.Database.EnsureCreated();
        }
        public List<Expense> GetAllExpenses()
        {
            return c.Expenses.OrderByDescending(e => e.Date).ToList();
        }
        public Expense GetExpenseById(Guid id)
        {
            return c.Expenses.FirstOrDefault(e => e.Id == id);
        }
        public void UpdateExpense(Expense expense)
        {
            if (expense == null) return;
            c.Expenses.Update(expense);
            c.SaveChanges();
        }
        public void AddExpense(Expense expense)
        {
            if (expense == null) return;
            c.Expenses.Add(expense);
            c.SaveChanges();
        }
        public void DeleteExpense(Guid id)
        { 
            var expense = c.Expenses.FirstOrDefault(x => x.Id == id);
            if(expense != null)
            {
                c.Expenses.Remove(expense);
                c.SaveChanges();
            }
        }
        public decimal GetTotalExpenses()
        {
            return c.Expenses.Any() ? c.Expenses.Sum(e => e.Amount) : 0;
        }
    }
}
