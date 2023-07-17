using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks.Contracts.Dto
{
    public class AddBlockDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(4,1000)]
        public int UnitCount { get; set; }
        [Required]
        public int ComplexId { get; set; }


    }
}
