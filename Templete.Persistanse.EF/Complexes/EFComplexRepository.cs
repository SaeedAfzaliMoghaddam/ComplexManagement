using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Services.Complexes.Contracts;

namespace Templete.Persistanse.EF.Complexes
{
    public class EFComplexRepository : ComplexRepository
    {
        private readonly DbSet<Complex> _complexes;
        public EFComplexRepository(EFDataContext context)
        {
            _complexes = context.Set<Complex>();
        }

        public void Add(Complex complex)
        {
            _complexes.Add(complex);
        }
    }
}
