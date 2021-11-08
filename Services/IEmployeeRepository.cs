using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee newEmployee);

        Employee Update(Employee updateEmployee);
        Employee GetEmployee(int id);
        Employee Delete(int id);
       
    }
}
