﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Complexes.Contracts.Dto
{
    public class GetComplexByIdDto
    {
        public GetComplexByIdDto()
        {
            Blocks = new List<GetBlocksOfComplexDto>();
        }

        public string Name { get; set; }
        public List<GetBlocksOfComplexDto> Blocks { get; set; }
    }
}
