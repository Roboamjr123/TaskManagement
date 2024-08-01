using AutoMapper;
using TaskManagement.Dto;
using TaskManagement.Models;

namespace TaskManagement.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Tasks, TaskDto>().ReverseMap();
        }
    }
}
