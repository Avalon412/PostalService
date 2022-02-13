using AutoMapper;
using PostalService.DAL.Models;
using PostalWebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, UserModel>();
        }
    }
}
