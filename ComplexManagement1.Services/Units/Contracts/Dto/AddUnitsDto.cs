using ComplexManagement1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Units.Contracts.Dto
{
    public class AddUnitsDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ResidenseType ResidenseType { get; set; }

        [Required]
        public int BlockId { get; set; }
    }
}
