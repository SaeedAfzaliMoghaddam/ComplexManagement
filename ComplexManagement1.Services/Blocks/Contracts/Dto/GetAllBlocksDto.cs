using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks.Contracts.Dto
{
    public class GetAllBlocksDto
    {
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int FilledUnits { get; set; }
        public int RemainedUnits { get; set; }
    }
}
