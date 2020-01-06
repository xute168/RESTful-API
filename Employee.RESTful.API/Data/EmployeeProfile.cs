using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.RESTful.API.Models;

namespace Employee.RESTful.API.Data
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<Employee, EmployeeModel>();
            this.CreateMap<Employee, CreateOrEditEmployeeModel>();
            this.CreateMap<CreateOrEditEmployeeModel, Employee>()
                .ForMember(r=>r.EmployeeId,opt=>opt.Ignore());

            this.CreateMap<EmployeeTask, EmployeeTaskModel>();
            this.CreateMap<EmployeeTaskModel,EmployeeTask> ();
            this.CreateMap<EmployeeTask, CreateOrEditEmployeeTaskModel>();
            this.CreateMap<CreateOrEditEmployeeTaskModel, EmployeeTask>()
                .ForMember(r => r.EmployeeTaskId, opt => opt.Ignore()); ;
        }
    }
}
