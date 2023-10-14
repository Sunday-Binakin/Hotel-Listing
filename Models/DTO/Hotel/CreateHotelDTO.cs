using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelListing.Data;

namespace HotelListing.Models.DTO.Hotel;

public class CreateHotelDTO
{
    [Required]
    [StringLength(maximumLength:75,ErrorMessage = "Hotel Must be shorter than this")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength:100,ErrorMessage = "Hotel Address be shorter than this")]
    public string Address { get; set; }
    [Required]
    [Range(1,5)]
    public double Rating { get; set; }
    [Required]
    public int CountryId { get; set; }
    
}