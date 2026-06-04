using ApiRest.Models.DTOs.AsignacionTurnoDTOs;
using ApiRest.Models.DTOs.CorreccionFichajeDTOs;
using ApiRest.Models.DTOs.DepartamentoDTOs;
using ApiRest.Models.DTOs.DisponibilidadDTOs;
using ApiRest.Models.DTOs.DocumentoEmpleadoDTOs;
using ApiRest.Models.DTOs.EmpleadoDTOs;
using ApiRest.Models.DTOs.EmpresaDTOs;
using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.DTOs.NotificacionDTOs;
using ApiRest.Models.DTOs.ReglaTurnoDTOs;
using ApiRest.Models.DTOs.ReporteDTOs;
using ApiRest.Models.DTOs.ResponsableDTOs;
using ApiRest.Models.DTOs.ResponsableEmpleadoDTOs;
using ApiRest.Models.DTOs.SedeDTOs;
using ApiRest.Models.DTOs.SolicitudAusenciaDTOs;
using ApiRest.Models.DTOs.TurnoDTOs;
using ApiRest.Models.DTOs.UserDTOs;
using ApiRest.Models.Entity;
using AutoMapper;


namespace ApiRest.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<EmpleadoEntity, EmpleadoDTO>().ReverseMap();
            CreateMap<CreateEmpleadoDTO, EmpleadoEntity>().ReverseMap();

            CreateMap<AsignacionTurnoEntity, AsignacionTurnoDTO>().ReverseMap();
            CreateMap<CreateAsignacionTurnoDTO, AsignacionTurnoEntity>().ReverseMap();

            CreateMap<AsignacionTurnoEntity, AsignacionTurnoUpdateDTO>().ReverseMap();

            CreateMap<CorreccionFichajeEntity, CorreccionFichajeDTO>().ReverseMap();
            CreateMap<CreateCorreccionFichajeDTO, CorreccionFichajeEntity>().ReverseMap();

            CreateMap<DisponibilidadEntity, DisponibilidadDTO>().ReverseMap();
            CreateMap<CreateDisponibilidadDTO, DisponibilidadEntity>().ReverseMap();

            CreateMap<DocumentoEmpleadoEntity, DocumentoEmpleadoDTO>().ReverseMap();
            CreateMap<CreateDocumentoEmpleadoDTO, DocumentoEmpleadoEntity>().ReverseMap();

            CreateMap<FichajeEntity, FichajeDTO>().ReverseMap();
            CreateMap<CreateFichajeDTO, FichajeEntity>().ReverseMap();

            CreateMap<NotificacionEntity, NotificacionDTO>().ReverseMap();
            CreateMap<CreateNotificacionDTO, NotificacionEntity>().ReverseMap();

            CreateMap<ReglaTurnoEntity, ReglaTurnoDTO>().ReverseMap();
            CreateMap<CreateReglaTurnoDTO, ReglaTurnoEntity>().ReverseMap();

            CreateMap<ReporteEntity, ReporteDTO>().ReverseMap();
            CreateMap<CreateReporteDTO, ReporteEntity>().ReverseMap();

            CreateMap<SedeEntity, SedeDTO>().ReverseMap();
            CreateMap<CreateSedeDTO, SedeEntity>().ReverseMap();

            CreateMap<SolicitudAusenciaEntity, SolicitudAusenciaDTO>().ReverseMap();
            CreateMap<CreateSolicitudAusenciaDTO, SolicitudAusenciaEntity>().ReverseMap();

            CreateMap<TurnoEntity, TurnoDTO>().ReverseMap();
            CreateMap<CreateTurnoDTO, TurnoEntity>().ReverseMap();

            CreateMap<UsuarioEntity, UserDto>().ReverseMap();
            CreateMap<UsuarioEntity, UserFlutterDto>().ReverseMap();


            CreateMap<EmpresaEntity, EmpresaDTO>().ReverseMap();
            CreateMap<CreateEmpresaDTO, EmpresaEntity>().ReverseMap();

            CreateMap<DepartamentoEntity, DepartamentoDTO>().ReverseMap();
            CreateMap<CreateDepartamentoDTO, DepartamentoEntity>().ReverseMap();

            CreateMap<ResponsableEntity, ResponsableDTO>().ReverseMap();
            CreateMap<CreateResponsableDTO, ResponsableEntity>().ReverseMap();

            CreateMap<ResponsableEmpleadoEntity, ResponsableEmpleadoDTO>().ReverseMap();
            CreateMap<CreateResponsableEmpleadoDTO, ResponsableEmpleadoEntity>().ReverseMap();

            // CreateMap<UserRegistrationDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
