using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models.DTO.User;

public class UserDto:LoginUserDTO
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
   
   
    
    
}