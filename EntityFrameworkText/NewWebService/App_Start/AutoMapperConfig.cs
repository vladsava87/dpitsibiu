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
                    cfg.CreateMap<t_absenta, AbsentaDTO>()
                        .ForMember(ignoraabsenta => ignoraabsenta.Elev, opt => opt.Ignore())
                        .ForMember(ignoramaterie => ignoramaterie.Materie, opt => opt.Ignore())
                        .ForMember(ignoraprofesor => ignoraprofesor.Profesor, opt => opt.Ignore());
                    cfg.CreateMap<t_clasa, ClasaDTO>()
                        .ForMember(ignoraelevi => ignoraelevi.Elevi, opt => opt.Ignore())
                        .ForMember(ignoraprofesori => ignoraprofesori.Diriginte, opt => opt.Ignore())
                        .ForMember(ignoraprofilul => ignoraprofilul.Profil, opt => opt.Ignore());
                    cfg.CreateMap<t_materie, MaterieDTO>()
                        .ForMember(ignoraabsente => ignoraabsente.Absente, opt => opt.Ignore())
                        .ForMember(ignoranote => ignoranote.Note, opt => opt.Ignore());
                    cfg.CreateMap<t_nota, NotaDTO>()
                        .ForMember(ignoraelev => ignoraelev.Elev, opt => opt.Ignore())
                        .ForMember(ignoramaterie => ignoramaterie.Materie, opt => opt.Ignore());
                    cfg.CreateMap<t_observatie, ObservatieDTO>()
                        .ForMember(ignoraprofesori => ignoraprofesori.Profesor, opt => opt.Ignore())
                        .ForMember(ignoraelevii => ignoraelevii.Elev, opt => opt.Ignore());
                    cfg.CreateMap<t_profesor, ProfesorDTO>()
                        .ForMember(ignoramaterii => ignoramaterii.Materii, opt => opt.Ignore());
                    cfg.CreateMap<t_profil, ProfilDTO>();
            });
        }
    }
}