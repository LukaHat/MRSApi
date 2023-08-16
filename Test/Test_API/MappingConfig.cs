using AutoMapper;
using Test_API.Models;
using Test_API.Models.Dto;

namespace Test_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();

            CreateMap<Razmjena, RazmjenaDTO>();
            CreateMap<RazmjenaDTO, Razmjena>();
        }
    }
}
