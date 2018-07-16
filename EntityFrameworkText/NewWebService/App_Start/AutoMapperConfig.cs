using AutoMapper;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;

namespace NewWebService.App_Start
{

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                    cfg.CreateMap<t_profil, ProfilDTO>();
                    cfg.CreateMap<t_clasa, ClasaDTO>()
                       .ForMember(ignoraelevii => ignoraelevii.Elevi, opt => opt.Ignore());
                    cfg.CreateMap<t_observatie, ObservatieDTO>();
                    cfg.CreateMap<t_profesor, ProfesorDTO>()
                       .ForMember(ignoramaterii => ignoramaterii.Materii, opt => opt.Ignore());
            });
        }
    }
}