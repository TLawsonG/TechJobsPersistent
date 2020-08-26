using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;
        public EmployerController(JobDbContext dbcontext) 
        {
            context = dbcontext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel viewmodel = new AddEmployerViewModel(context.Employers.ToList());
            return View(viewmodel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Employer NewEmployer = new Employer
                {
                Name = viewmodel.Name,
                Location = viewmodel.Location,
                };
                context.Employers.Add(NewEmployer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            return View(viewmodel);
        }

        public IActionResult About(int id)
        {
            Employer Employer = context.Employers.Single(e => e.Id == id);
            EmployerAboutViewModel viewmodel = new EmployerAboutViewModel(Employer);
            return View();
        }
    }
}
