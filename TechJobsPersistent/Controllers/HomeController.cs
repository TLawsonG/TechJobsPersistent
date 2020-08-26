using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            AddJobViewModel viewmodel = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());
            return View(viewmodel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel viewmodel)
        {

            if (ModelState.IsValid)
            {
                
                    Job job = new Job
                {
                    Name = viewmodel.Name,
                    Employer = context.Employers.Find(viewmodel.EmployerId),
                    JobSkills = new List<JobSkill>()
                };
                context.Jobs.Add(job);
                foreach (int skillId in viewmodel.SkillId)
                {
                    JobSkill jobskill = new JobSkill(job.Id, skillId);
                    jobskill.Job = context.Jobs.Find(job.Id);
                    jobskill.Skill = context.Skills.Find(skillId);
                    context.JobSkills.Add(jobskill);
                    job.JobSkills.Add(jobskill);
                }
                context.SaveChanges();
                return Redirect("/Home");
            }
            return View(viewmodel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
