﻿using CDP.Domain.Identity;
using CDP.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CDP.Application.Dtos
{
    public class FarmDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageURL { get; set; }
        public double Size { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<EmployeesFarms> FamsControllers { get; set; }
        public IEnumerable<Plot> Plots { get; set; }
        public IEnumerable<EmployeeService> Employees { get; set; }
    }
}
