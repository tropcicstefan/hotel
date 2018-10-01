using AutoMapper;
using hotel.DTO;
using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.App_Start
{
    public class ApplicationProfile : Profile
    {
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<ApplicationProfile>();
            });
        }

        public ApplicationProfile()
        {
            
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Gost, GostDto>().ReverseMap();
            CreateMap<Soba, SobaDto>().ReverseMap();
            CreateMap<SobaTip, SobaTipDto>().ReverseMap();
            CreateMap<ElementPonude, ElementPonudeDto>().ReverseMap();

            CreateMap<PrivremeniRacun, PrivremeniRacunDto>().ReverseMap();
            CreateMap<Stavke, StavkeDto>().ReverseMap();
            CreateMap<Rezervacija, RezervacijaDto>().ReverseMap();
            //CreateMap<List<Soba>, List<SobaDto>>().ReverseMap();
            //CreateMap<SobaRezervacijaDto, List<SobaDto>>().ConvertUsing(source => source.SlobodneSobas.Select(s => new SobaDto
            //{
            //    HotelID = s.HotelID,
            //    ID = s.ID,
            //    SobaTipID = s.SobaTipID
            //}
            //).ToList());

        }

    }
}