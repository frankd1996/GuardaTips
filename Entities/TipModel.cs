using Abstractions;
using SQLite;
using System;

namespace Entities
{
    public class TipModel:Entity
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}
