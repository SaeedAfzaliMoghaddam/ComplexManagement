using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Blocks.Contracts
{
    public interface BlockRepository
    {
        bool CheckUnitName(int id,string unitName);
        bool IsExist(int id);
    }
}
