using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "JobName is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employer ID is required")]
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers;

        public List<Skill> Skills { get; set; }
        public List<int> SkillId { get; set; }

        public AddJobViewModel()
        {

        }
        public AddJobViewModel(List<Employer> EmployersList, List<Skill> skills)
        {
            Skills = skills;
            Employers = new List<SelectListItem>();
            
                foreach (Employer Employer in EmployersList)
            {
                Employers.Add(new SelectListItem
                {
                    Value = Employer.Id.ToString(),
                    Text = Employer.Name
                });       
            }
        }
    }
}
