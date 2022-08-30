using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class IdiomasExterno
    {
        public int Id { get; set; }
        public int IdIdioma { get; set; }
        public int IdExterno { get; set; }
        public bool? Activo { get; set; }
        public string Observaciones { get; set; }
        public int? Escribir { get; set; }
        public int? Escuchar { get; set; }
        public int? Hablar { get; set; }
        public int? Leer { get; set; }
        public int? IdCalificativo { get; set; }

        public virtual Catalogo CatalogoEscribir { get; set; }
        public virtual Catalogo CatalogoEscuchar { get; set; }
        public virtual Catalogo CatalogoHablar { get; set; }
        public virtual Catalogo Calificativo { get; set; }
        public virtual ElementosExterno ElementoExterno { get; set; }
        public virtual Catalogo CatalogoLeer { get; set; }
    }
}
