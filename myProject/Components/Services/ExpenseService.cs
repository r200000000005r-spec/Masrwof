using myProject.Components.Data;
using myProject.Components.Interfaces;
using myProject.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.Components.Services
{
    public class ExpenseService : IExpenseService
    {
        //Dependency Injection
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }
        public void InitializeDatabase()
        {
            _context.Database.EnsureCreated();
        }

        public List<Expense> GetAllExpenses()
        {
            return _context.Expenses.OrderByDescending(e => e.Date).ToList();
        }

        public Expense GetExpenseById(Guid id)
        {
            return _context.Expenses.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateExpense(Expense expense)
        {
            if (expense == null) return;

            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null) return;

            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public void DeleteExpense(Guid id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public decimal GetTotalExpenses()
        {

            return _context.Expenses.Any() ? _context.Expenses.Sum(e => e.Amount) : 0;
        }
    }
}
