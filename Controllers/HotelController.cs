using AutoMapper;
using HotelListing.Models.DTO.Hotel;
using HotelListing.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController:ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CountryController> _logger;
    private readonly IMapper _mapper;

    public HotelController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHotels()
    {
        try
        {
            var hotels = await _unitOfWork.Hotels.GetAll();
            var results = _mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"Something Went wrong in the {nameof(GetHotels)}");
            return StatusCode(500,"Internal Server Error, Please try Again Later");
        }
    }
    
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHotel(int id)
    {
        try
        {
            var hotel = await _unitOfWork.Hotels.Get(c=>c.Id==id,new List<string>{"Country"});
            var results = _mapper.Map<HotelDTO>(hotel);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"Something Went wrong in the {nameof(GetHotel)}");
            return StatusCode(500,"Internal Server Error, Please try Again Later");
        }
    }
}