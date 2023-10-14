namespace HotelListing.Data;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    
    public virtual IList<Hotel> Hotels { get; set; } // if requested this can include the list of hotels associated with the country 
}