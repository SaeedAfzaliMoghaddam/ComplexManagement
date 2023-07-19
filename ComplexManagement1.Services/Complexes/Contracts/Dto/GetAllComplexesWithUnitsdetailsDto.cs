using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts.Dto
{
    public class GetAllComplexesWithUnitsdetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilledUnitCount { get; set; }
        public int RemainingUnitCount { get; set; }

    }
}
