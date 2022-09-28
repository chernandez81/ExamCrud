using AutoMapper;
using Exam.SqlServer.Entities;

namespace Exam.WebApp.Mapper;
public class ExamProfile : Profile
{
	public ExamProfile()
	{
		CreateMap<Suscripcion, Model.Suscripcion>()
			.ForMember(dest => dest.FechaIngreso, src => src.MapFrom(s => s.FechaAlta))
			.ForMember(dest => dest.FechaVencimiento, src => src.MapFrom(s => s.FechaFin))
			.ForMember(dest => dest.Comentario, src => src.MapFrom(s => s.MotivoFin));

        CreateMap<Model.Suscripcion,Suscripcion>()
            .ForMember(dest => dest.FechaAlta, src => src.MapFrom(s => s.FechaIngreso))
            .ForMember(dest => dest.FechaFin, src => src.MapFrom(s => DateTime.Now.AddYears(1)))
            .ForMember(dest => dest.MotivoFin, src => src.MapFrom(s => s.Comentario));

        CreateMap<Suscriptor, Model.Suscriptor>()
            .ForMember(dest => dest.Username, src => src.MapFrom(s => s.NombreUsuario))
            .ForMember(dest => dest.Pwd, src => src.MapFrom(s => s.Password))
            .ForMember(dest => dest.Estado, src => src.MapFrom(s => s.Estado.ToString()))
            .ForMember(dest => dest.TipoDocumento, src => src.MapFrom(s => s.TipoDocumento.ToString()));

        CreateMap<Model.Suscriptor, Suscriptor>()
          .ForMember(dest => dest.NombreUsuario, src => src.MapFrom(s => s.Username))
          .ForMember(dest => dest.Password, src => src.MapFrom(s => s.Pwd))
          .ForMember(dest => dest.Estado, src => src.MapFrom(s => Convert.ToInt32( s.Estado)))
          .ForMember(dest => dest.TipoDocumento, src => src.MapFrom(s => Convert.ToInt32( s.TipoDocumento)));
    }
}
