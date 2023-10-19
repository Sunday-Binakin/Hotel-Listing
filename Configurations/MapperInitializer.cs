using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using HotelListing.Models.DTO.Hotel;
using HotelListing.Models.DTO.User;

namespace HotelListing.Configurations;

public class MapperInitializer:Profile
{
    public MapperInitializer()
    {
        CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Country, CreateHotelDTO>().ReverseMap();
        CreateMap<Hotel, HotelDTO>().ReverseMap();
        CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        CreateMap<ApiUser, UserDto>().ReverseMap();
    }
}