using AutoMapper;
using Shopping.ApplicationService.DTO.Request;
using Shopping.ApplicationService.DTO.Response;
using Shopping.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationService.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
