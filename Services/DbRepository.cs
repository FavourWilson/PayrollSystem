using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DbRepository : IEmployeeRepository, IExpensesRepository, ISalary,IncomeRepository
    {
        private readonly AppDbContext context;

        public DbRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
            return newEmployee;
        }

        public Expenses Add(Expenses newExpenses)
        {
            context.Expenses.Add(newExpenses);
            context.SaveChanges();
            return newExpenses;
        }

        public Salary Add(Salary Addsalary)
        {
            context.Salaries.Add(Addsalary);
            context.SaveChanges();
            return Addsalary;
        }

        public Income Add(Income addIncomes)
        {
            context.incomes.Add(addIncomes);
            context.SaveChanges();
            return addIncomes;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = context.Employees.Find(id);
            if(employeeToDelete != null)
            {
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }

            return employeeToDelete; 
        }

        public Expenses DeleteExpense(int id)
        {
            Expenses expenses = context.Expenses.Find(id);
            if(expenses != null)
            {
                context.Expenses.Remove(expenses);
                context.SaveChanges();
            }

            return expenses;
        }

        public Employee GetEmployee(int id)
        {
           
            return context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Expenses GetExpense(int id)
        {
            return context.Expenses.Find(id);
        }

        public IEnumerable<Expenses> GetExpenses()
        {
            return context.Expenses.ToList();
        }

        public Income GetIncome(int id)
        {
            return context.incomes.Find(id);
        }

        public IEnumerable<Income> GetIncomes()
        {
            return context.incomes.ToList();
        }

        public IEnumerable<Salary> GetSalaries()
        {
            return context.Salaries.ToList();
        }

        public Salary GetSalary(int id)
        {
            return context.Salaries.Find(id);
        }

        public Salary GetSalaryByemployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = context.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateEmployee;
        }

        public Expenses Update(Expenses updateExpenses)
        {
            var expense = context.Expenses.Attach(updateExpenses);
            expense.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateExpenses;
        }

        public Salary Update(int id, Salary updateSalary)
        {
            var salary = context.Salaries.FirstOrDefault(n => n.Id == id);
            if(salary != null)
            {
                salary.AmountPaid = updateSalary.AmountPaid;
                salary.Department = updateSalary.Department;
                salary.DatePaid = updateSalary.DatePaid;
                

                foreach(var item in updateSalary.Employee)
                {
                    var employee = new Employee();
                    {
                        employee.Name = item.Name;
                    }
                }

                context.Salaries.Update(salary);
                context.SaveChanges();

                
            }
            return updateSalary;
        }

        public Income Update(Income updateIncome)
        {
            var incomes = context.incomes.Attach(updateIncome);
            incomes.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateIncome;
        }

        Salary ISalary.Delete(int id)
        {
            Salary salary = context.Salaries.Find(id);
            if(salary != null)
            {
                context.Salaries.Remove(salary);
                context.SaveChanges();
            }
            return salary;
        }

        Income IncomeRepository.Delete(int id)
        {
            Income income = context.incomes.Find(id);
            if (income != null)
            {
                context.incomes.Remove(income);
                context.SaveChanges();
            }

            return income;
        }
    }
}
