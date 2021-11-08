using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace PayrollSystem.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepository = employeeRepository;
            WebHostEnvironment = webHostEnvironment;
        }


        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile photo { get;set; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.GetEmployee(id);
            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    if (Employee.Photopath != null)
                    {
                        string filepath = Path.Combine(WebHostEnvironment.WebRootPath, "images", Employee.Photopath);
                        System.IO.File.Delete(filepath);
                    }
                    Employee.Photopath = ProcessUploadFile();
                }
                Employee = employeeRepository.Update(Employee);
                return RedirectToPage("Index");
            }
            return Page();
        }

        private string ProcessUploadFile()
        {
            string uniqueFilename = null;
            if(photo != null)
            {
                string uploadFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFilename);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }

            return uniqueFilename;
        }
    }
}
