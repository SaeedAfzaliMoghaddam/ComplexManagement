using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks.Contracts.Dto
{
    public class GetBlockByIdDto
    {
        public GetBlockByIdDto()
        {
            Units = new List<GetUnitsOfBlockDto>();
        }

        public string Name { get; set; }
        public List<GetUnitsOfBlockDto> Units { get; set; }
    }
}
