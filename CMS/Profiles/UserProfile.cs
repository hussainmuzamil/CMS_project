using System;
using CMS.Dtos;
using AutoMapper;
using CMS.Models;

namespace CMS.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<User, UserReadDto>();
        }
    }
}
