using Akij_Food_Crud_Operation_Api.data;
using Akij_Food_Crud_Operation_Api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akij_Food_Crud_Operation_Api.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<ColdDrink, ColdDrinkDTO>().ReverseMap();
            CreateMap<ColdDrink, CreateColdDrinkDTO>().ReverseMap();
        }
    }
}
