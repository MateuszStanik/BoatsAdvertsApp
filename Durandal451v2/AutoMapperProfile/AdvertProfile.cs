using AutoMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatsAdvertsApp.AutoMapperProfile
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<Advert, Advert>();
        }
    }
}