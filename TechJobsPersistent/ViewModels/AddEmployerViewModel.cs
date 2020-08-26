using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;
using System.ComponentModel.DataAnnotations;


namespace TechJobsPersistent.ViewModels
 
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        public AddEmployerViewModel()
        {

        }
        public AddEmployerViewModel(List<Employer> EmployersList) 
        {
            foreach (Employer Employer in EmployersList)
            {
                Name = Employer.Name;
                Location = Employer.Location;
            }
        }
    }
}
