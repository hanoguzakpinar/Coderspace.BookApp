using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookApp.Entities;
using BookApp.Entities.Dtos.AuthDtos;

namespace BookApp.Services.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegistrationDto>().ReverseMap();
        }
    }
}
