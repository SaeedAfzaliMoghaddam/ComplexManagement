
using ComplexManagement1.Persistance.EF;
using ComplexManagement1.Services.Unit.Test.DataBaseConfig;
namespace ComplexManagement1.Services.Unit.Test.DataBaseConfig.Unit;

public class BusinessUnitTest
{
    protected EFDataContext DbContext { get; }
    protected EFDataContext SetupContext { get; }
    protected EFDataContext ReadContext { get; }


    protected BusinessUnitTest()
    {
        var db = new EFInMemoryDatabase();

        DbContext = db.CreateDataContext<EFDataContext>();
        SetupContext = db.CreateDataContext<EFDataContext>();
        ReadContext = db.CreateDataContext<EFDataContext>();
    }



    protected void Save<T>(T entity)
    {
        if (entity != null)
        {
            DbContext.Manipulate(_ => _.Add(entity));
        }
    }

    public void Save<T>(params T[] entities)
    {
        foreach (var item in entities)
            DbContext.Manipulate(_ => _.Add(item!));
    }

    public void Save()
    {
        DbContext.SaveChanges();
    }
}