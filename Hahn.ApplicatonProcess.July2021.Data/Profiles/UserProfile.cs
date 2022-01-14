using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Data.DTO;
using Hahn.ApplicatonProcess.July2021.Domain.Models;

namespace Hahn.ApplicatonProcess.July2021.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Query, User>().ReverseMap();
            CreateMap<CreateUser, User>().ReverseMap();
        }
    }
}
