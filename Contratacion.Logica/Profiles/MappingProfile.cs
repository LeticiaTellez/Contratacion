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

            CreateMap<ExperienciaExterno, ExperienciaElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<EstudiosExterno, EstudioElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<EspecialidadExterno, EspecialidadElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<ReferenciasExterno, ReferenciaParticularEEVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<LocalidadExterno, LocalidadElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.EstaActivo = 1);

            CreateMap<IdiomasExterno, IdiomaElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<ArchivoExterno, ArchivoElementoExternoVM>().ReverseMap()
                .BeforeMap((s, d) => d.Activo = true);

            CreateMap<AplicantesVacante, AplicanteVacanteVM>().ReverseMap()
                .BeforeMap((s, d) => d.Estado = true);
        }
    }
}
