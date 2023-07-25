


using Templete.Persistanse.EF.Complexes;
using Templete.Persistanse.EF;

namespace Templete.TestTools.Factories.Complexes
{
    public static class ComplexServiceFactory
    {
        public static ComplexAppService Generate(EFDataContext context) 
        {
            var repository = new EFComplexRepository(context);
            var unitOfWork = new EFUnitOfWork(context);
            var sut = new ComplexAppService(repository, unitOfWork);
            return sut;
        }
    }
}
