﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts.Dto
{
    public class AddComplexDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(4,1000)]
        public int UnitCount { get; set; }
    }
}
