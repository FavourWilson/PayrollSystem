using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IncomeRepository
    {
        IEnumerable<Income> GetIncomes();
        Income Add(Income addIncomes);
        Income Update(Income updateIncome);
        Income Delete(int id);
        Income GetIncome(int id);
    }
}
