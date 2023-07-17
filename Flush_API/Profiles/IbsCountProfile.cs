using AutoMapper;
using Flush_API.Dtos;
using Flush_API.Models;

namespace Flush_API.Profiles
{
    public class IbsCountProfile : Profile
    {
        public IbsCountProfile() 
        {
            //Source -> Target
            CreateMap<IbsCount, IbsCountReadDto>();
            CreateMap<IbsCountCreateDto, IbsCount>();
            CreateMap<IbsCountUpdateDto, IbsCount>();
        }
    }
}
