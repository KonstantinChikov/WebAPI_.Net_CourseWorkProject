﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.LocationTypeDto
{
    public class LocationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Villas { get; set; }
    }
}
