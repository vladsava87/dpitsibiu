﻿using AutoMapper;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using System.Linq;

namespace NewWebService.App_Start
{

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<t_absenta, AbsentaDTO>();
                     //   .ForMember(ignoraabsenta => ignoraabsenta.Elev, opt => opt.Ignore());
                     //   .ForMember(ignoramaterie => ignoramaterie.Materie, opt => opt.Ignore())
                     //   .ForMember(ignoraprofesor => ignoraprofesor.Profesor, opt => opt.Ignore());

                cfg.CreateMap<t_clasa, ClasaDTO>();
                    //.ForMember(ignoraelevi => ignoraelevi.Elevi, opt => opt.Ignore())
                    //.ForMember(ignoraprofesori => ignoraprofesori.Diriginte, opt => opt.Ignore())
                    //.ForMember(ignoraprofilul => ignoraprofilul.Profil, opt => opt.Ignore());

                //cfg.CreateMap<t_clasa, ClasaDTO>()
                //        .ForMember(clasa => clasa.Elevi, opt => opt.MapFrom(op => op.Elevi.Select(e => e.Id).ToList()));

                cfg.CreateMap<t_elev, ElevDTO>()
                        .ForMember(ignoranote => ignoranote.Note, opt => opt.Ignore())
                        .ForMember(ignoraabsente => ignoraabsente.Absente, opt => opt.Ignore())
                        .ForMember(ignoraobservatii => ignoraobservatii.Observatii, opt => opt.Ignore());
                        //.ForMember(ignoraclasa => ignoraclasa.ClasaID, opt => opt.Ignore());

                    cfg.CreateMap<t_materie, MaterieDTO>()
                        .ForMember(ignoraabsente => ignoraabsente.Absente, opt => opt.Ignore())
                        .ForMember(ignoranote => ignoranote.Note, opt => opt.Ignore())
                        .ForMember(ignoraprofesor => ignoraprofesor.Profesor, opt => opt.Ignore());

                cfg.CreateMap<t_nota, NotaDTO>()
                    .ForMember(ignoraelev => ignoraelev.Elev, opt => opt.Ignore());

                cfg.CreateMap<t_observatie, ObservatieDTO>();
                      //  .ForMember(ignoraprofesori => ignoraprofesori.Profesor, opt => opt.Ignore())
                       // .ForMember(ignoraelevii => ignoraelevii.Elev, opt => opt.Ignore());

                cfg.CreateMap<t_profesor, ProfesorDTO>()
                    .ForMember(ignoraabsente => ignoraabsente.Absente, opt => opt.Ignore())
                    .ForMember(ignoramaterii => ignoramaterii.Materie, opt => opt.MapFrom(x => x.Materie.Select(y => y.Materie).ToList()))
                    .ForMember(ignoraobservatii => ignoraobservatii.Observatii, opt => opt.Ignore())
                    .ForMember(ingnoreClasa => ingnoreClasa.Clasa, opt => opt.Ignore())
                    .ForMember(dto => dto.Clase, opt => opt.MapFrom(x => x.Clase.Select(y => y.Clasa).ToList()));

                cfg.CreateMap<t_profil, ProfilDTO>()
                        .ForMember(ignoraclase => ignoraclase.Clase, opt => opt.Ignore());
            });
        }
    }
}