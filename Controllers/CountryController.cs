using AutoMapper;
using HotelListing.Models;
using HotelListing.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CountryController:ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CountryController> _logger;
    private readonly IMapper _mapper;
    
   
    public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCountires()
    {
        try
        {
            var countries = await _unitOfWork.Countries.GetAll();
            var results = _mapper.Map<IList<CountryDTO>>(countries);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"Something Went wrong in the {nameof(GetCountires)}");
           return StatusCode(500,"Internal Server Error, Please try Again Later");
        }
    }
    
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCountry(int id)
    {
        try
        {
            var country = await _unitOfWork.Countries.Get(c=>c.Id==id,new List<string>{"Hotels"});
            var results = _mapper.Map<CountryDTO>(country);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"Something Went wrong in the {nameof(GetCountry)}");
            return StatusCode(500,"Internal Server Error, Please try Again Later");
        }
    }
}