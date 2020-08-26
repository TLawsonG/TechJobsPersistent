using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class EmployerAboutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public EmployerAboutViewModel(Employer employer)
        {
            Id = employer.Id;
            Name = employer.Name;
            Location = employer.Location;
        }
    }
}

