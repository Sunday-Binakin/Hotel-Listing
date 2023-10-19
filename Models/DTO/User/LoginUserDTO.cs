using System.ComponentModel.DataAnnotations;


namespace HotelListing.Models.DTO.User;

public class LoginUserDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [StringLength(15,ErrorMessage = "Your Password Limit is {2} to {1}",MinimumLength = 6 )]
    public string Password { get; set; }
}