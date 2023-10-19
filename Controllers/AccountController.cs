using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.DTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AccountController:ControllerBase
{
    private readonly UserManager<ApiUser> _userManager;
    //private readonly SignInManager<ApiUser> _signInManager;
    private readonly ILogger<AccountController> _logger;
    private readonly IMapper _mapper;

    public AccountController(UserManager<ApiUser> userManager,  ILogger<AccountController> logger, IMapper mapper)
    {
        _userManager = userManager;
       // _signInManager = signInManager;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        _logger.LogInformation($"Registration Attempt for {userDto.Email}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }
                return BadRequest(ModelState);
            }

            return Accepted();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"Something Went Wrong in the {nameof(Register)}");
            return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
        }
    }
    
    // [HttpPost]
    // [Route("login")]
    // public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDto)
    // {
    //     _logger.LogInformation($"Login Attempt for {loginUserDto.Email}");
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }
    //
    //     try
    //     {
    //         var result = await _signInManager.PasswordSignInAsync(loginUserDto.Email,loginUserDto.Password, false, false);
    //         if (!result.Succeeded)
    //         {
    //             return Unauthorized(loginUserDto);
    //         }
    //
    //         return Accepted();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex,$"Something Went Wrong in the {nameof(Register)}");
    //         return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
    //     }
    // }
}