﻿using CWProject.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CWProject.Models.DtoModels.LocationTypeDto
{
    public class LocationTypeUpdateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
