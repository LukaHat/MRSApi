using AutoMapper;
using Studentska_razmjena_API.Dto;
using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Razmjena,RazmjenaDto>();
        }
    }
}
