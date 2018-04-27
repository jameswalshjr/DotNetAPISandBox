using AutoMapper;
using DotNetAPISandBox.Domain.Dto;
using DotNetAPISandBox.Domain.Entity;

namespace DotNetAPISandBox.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FunctionStatus, FunctionStatusEntity>().ReverseMap();
        }
    }
}
