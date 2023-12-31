using HotelListing.Data;

namespace HotelListing.Repository.Interface;

public interface IUnitOfWork:IDisposable
{
    IGenericRepository<Country> Countries { get;  }
    IGenericRepository<Hotel> Hotels { get;  }
    Task Save();
}