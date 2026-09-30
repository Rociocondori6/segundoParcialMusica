using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; } // Duración en segundos

        public int ArtistaId { get; set; } // Clave foránea para la relación con Artista
        public Artista artista { get; set; } // Relación con la clase Artista
    }
}
