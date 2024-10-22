﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(16, 65)]
        public int Age { get; set; }

        public string PositionName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Address { get; set; }
    }
}
