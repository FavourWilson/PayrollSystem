using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISalary
    {
        IEnumerable<Salary> GetSalaries();
        Salary Add(Salary Addsalary);
        Salary Update(int id, Salary updateSalary);
        Salary GetSalaryByemployee(int id);

        Salary GetSalary(int id);
        Salary Delete(int id);
    }
}
