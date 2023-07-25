using System;
using System.ComponentModel.DataAnnotations;

public class AddComplexDto
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [Range(4,1000)]
    public int UnitCapacity { get; set; }
}


