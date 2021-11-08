using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IExpensesRepository
    {
        IEnumerable<Expenses> GetExpenses();
        Expenses Add(Expenses newExpenses);
        Expenses Update(Expenses updateExpenses);
        Expenses GetExpense(int id);
        Expenses DeleteExpense(int id);
    }
}
