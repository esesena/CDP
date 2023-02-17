﻿using CDP.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CDP.Application.Dtos
{
    public class PlotDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Size { get; set; }
        public string SoilType { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public IEnumerable<PlantingPlot> PlantingPlot { get; set; }
    }
}
