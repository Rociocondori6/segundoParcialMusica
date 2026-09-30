using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public List<Cancion> Canciones { get; set; } // Relación con la clase Cancion
    }
}
