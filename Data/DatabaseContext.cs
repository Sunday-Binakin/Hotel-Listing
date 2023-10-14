using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data;

public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions options):base(options)
    {
        
    }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Country>().HasData(
             new Country
             {
                 Id = 1,
                 Name = "Germany",
                 ShortName = "Gr"
             },
        new Country
        {
            Id = 2,
            Name = "Ghana",
            ShortName = "Gh"
        },
        new Country
        {
            Id = 3,
            Name = "Eritrea",
            ShortName = "Er"
        });
        builder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id =1 ,
                Name = "Sunset Paradise Hotel",
                Address = "123 Ocean View Avenue, Beach Town",
                CountryId = 1,
                Rating = 4.5
            },
            new Hotel { Id =2 ,
                Name = "Mountain View Lodge",
                Address = "456 Pine Street, Alpine Village",
                CountryId = 2,
                Rating = 4.0 },
            new Hotel { Id =3 ,
                Name = "City Lights Inn",
                Address = "789 Downtown Street, Urban Center",
                CountryId = 3,
                Rating = 3.5 });
    }
}
