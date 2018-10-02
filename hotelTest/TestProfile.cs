using AutoMapper;
using hotel.DTO;
using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelTest
{
    class TestProfile : Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<TestProfile>();
            });
            
        }

        public static void De()
        {
            Mapper.Reset();
        }
        public TestProfile()
        {

            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Gost, GostDto>().ReverseMap();
            CreateMap<Soba, SobaDto>().ReverseMap();
            CreateMap<SobaTip, SobaTipDto>().ReverseMap();
            CreateMap<ElementPonude, ElementPonudeDto>().ReverseMap();

            CreateMap<PrivremeniRacun, PrivremeniRacunDto>().ReverseMap();
            CreateMap<Stavke, StavkeDto>().ReverseMap();
            CreateMap<Rezervacija, RezervacijaDto>().ReverseMap();

            

        }
    }
}
