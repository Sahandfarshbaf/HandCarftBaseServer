using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using HandCarftBaseServer.Tools;

namespace HandCarftBaseServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorDto>();
            //    CreateMap<UserRegistrationModel, User>()
            //        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));



        }
    }
}