using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Services.Contracts
{
    public interface UnitOfWork
    {
        void Complete();
    }
}
