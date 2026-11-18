using Masrwof.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Components.Interfaces
{
    public interface IExpenseService
    {
        Expense GetExpenseById(Guid id);
        void DeleteExpense(Guid id);
        void UpdateExpense(Expense expense);
        List<Expense> GetAllExpenses();
        void AddExpense(Expense expense);
        decimal GetTotalExpenses();
    }
}
