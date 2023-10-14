using HotelListing.Data;
using HotelListing.Repository.Interface;

namespace HotelListing.Repository.Implementation;

public class UnitOfWork:IUnitOfWork
{
    private readonly DatabaseContext _databaseContext;
    private IGenericRepository<Country> _countries;
    private IGenericRepository<Hotel> _hotels;

    public UnitOfWork(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void Dispose()
    {
        _databaseContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_databaseContext);
        
    

    public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_databaseContext);
    public async Task Save()
    {
       await  _databaseContext.SaveChangesAsync();
    }
}