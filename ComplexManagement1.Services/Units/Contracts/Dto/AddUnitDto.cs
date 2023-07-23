using ComplexManagement1.Entities;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagement1.Services.Units.Contracts.Dto
{
    public class AddUnitDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int BlockId { get; set; }

        [Required]
        public ResidenseType ResidenseType { get; set; }
    }
}