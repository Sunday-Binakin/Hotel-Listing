using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models;

public class CreateCountryDTO
{
    [Required]
    [StringLength(maximumLength:50,ErrorMessage = "Country Name is too Long")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength:2,ErrorMessage = "Country Short Name is too Long")]
    public string ShortName { get; set; }
}