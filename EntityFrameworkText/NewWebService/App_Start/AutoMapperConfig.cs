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
                });

        }
    }
}