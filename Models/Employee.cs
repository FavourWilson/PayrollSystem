using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Photopath { get; set; }
        [Required]
        public Dept Department { get; set; }

        public List<Employee_Expenses> Employee_Expenses { get; set; }

        public int? SalaryId { get; set; }
        public Salary Salary { get; set; }

        public int? IncomeId { get; set; }
        public Income Income { get; set; }
    }
}
