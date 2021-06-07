using AutoMapper;
using Core.Entites.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProjectCreationDto, Project>();
            CreateMap<ProjectDetailDto, Project>();
            CreateMap<WorkerCreationDto,Worker>();
            CreateMap<WorkerSalaryDto, Salary>();
            CreateMap<WorkerDto, Worker>();

        }
    }
}
