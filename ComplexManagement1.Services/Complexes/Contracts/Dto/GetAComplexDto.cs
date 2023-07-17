using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts.Dto
{
    public class GetAComplexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilledUnits { get; set; }
        public int RemainingUnits { get; set; }
        public int BlockCount { get; set; }




    }
}
