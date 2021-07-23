using AutoMapper;
using LearnerAPI.DTO;
using LearnerAPI.Models;

namespace DefaultNamespace
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<StudentCreateDTO, Student>();
            
            CreateMap<Student, StudentDTO>().ForMember(dto => dto.StudyId, o => o.MapFrom(src => src.Study.StudyId));
            CreateMap<Student, StudentCreateDTO>();

        }
    }
}