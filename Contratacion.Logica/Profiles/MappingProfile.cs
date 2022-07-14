using AutoMapper;
using Contratacion.Datos.Models;
using Contratacion.Modelos.ElementosExternos;
using Contratacion.Modelos.Vacantes;
using System;

namespace Contratacion.Logica.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ElementosExterno, ElementoExternoResponse>().ReverseMap();
            CreateMap<ElementosExterno, ElementoExternoRequest>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<ExperienciaXEexterno, ExperienciaElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<EstudiosXEexterno, EstudioElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<EspecialidadXEexterno, EspecialidadElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<ReferenciaParticularesEexterno, ReferenciaParticularEEVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<LocalidadElementoExterno, LocalidadElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.EstaActivo = 1);

            CreateMap<IdiomasXEexterno, IdiomaElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<ArchivoXExterno, ArchivoElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<AplicantesVacante, AplicanteVacanteVM>().ReverseMap()
                .BeforeMap((s, d) => d.EstadoAplicacion = true);
        }
    }
}
