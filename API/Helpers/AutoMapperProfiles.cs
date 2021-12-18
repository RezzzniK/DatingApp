using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{

    /*the purpose of automappper is helps us map one object to another*/
    public class AutoMapperProfiles : Profile//we deriving from the class
                                             //Profile from automapper lib
    {
        //generating empty constructor
        public AutoMapperProfiles()
        {
            //creating function that will automapp from one to another object
            CreateMap<AppUser, MembersDto>()
            ./*we will add some extra
            configurations here to fill PhotoUrl property*/
            ForMember/*means which property we want to
            affect*/(destination=>destination.PhotoUrl,
                    /*now we adding some options*/opt=>
                    opt.MapFrom(source=>source.Photos.FirstOrDefault(
                        x=>x.IsMain).Url
                    ))
            .ForMember(dest=>dest.Age,opt=>opt.MapFrom(
                src=>src.DateOfBirth.CalculateAge()
            ));
            CreateMap<Photo,PhotoDto>();
        }
    }
}