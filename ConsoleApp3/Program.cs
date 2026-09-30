using ClassLibrary1.Models;
using ClassLibrary1.Repositories;
using System.Diagnostics;

GenericRepository <Cancion> cancionRepository = new GenericRepository<Cancion>();
GenericRepository<Artista> artistaRepository = new GenericRepository<Artista>();

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Alta Artista");
    Console.WriteLine("2. Alta Canción");
    Console.WriteLine("3. Ver Canciones de un Artista");
    Console.WriteLine("4. Mostrar canciones mas largas");
    Console.WriteLine("5. Cantidad total de canciones");
    Console.WriteLine("6. Mostrar canciones ordenadas alfabeticamente");
    Console.WriteLine("7. Verificar si existen canciones registradas");
    Console.WriteLine("8. Salir");
    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            AgregarArtista();
            break;
        case "2":
            AgregarCancion();
            break;
        case "3":
            VerCancionesDeArtista();
            break;
        case "4":
            MostrarCancionesMasLargas();
            break;
        case "5":
            CantidadTotalDeCanciones();
            break;
        case "6":
            MostrarCancionesOrdenadasAlfabeticamente();
            break;
        case "7":
            VerificarExistenciaDeCanciones();
            break;
        case "8":
            Console.WriteLine("Programa finalizado.");
            return; 
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

static void AgregarArtista()
{
    Console.WriteLine("Ingrese el nombre del artista:");
    string nombre = Console.ReadLine();
    Artista artista = new Artista { Nombre = nombre };
    GenericRepository<Artista> artistaRepository = new GenericRepository<Artista>();
    artistaRepository.Agregar(artista);
    Console.WriteLine("Artista agregado exitosamente.");
}

static void AgregarCancion()
{
    Console.WriteLine("Ingrese el título de la canción:");
    string titulo = Console.ReadLine();
    Console.WriteLine("Ingrese la duración de la canción en segundos:");
    int duracion = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el ID del artista:");
    int artistaId = int.Parse(Console.ReadLine());
    Cancion cancion = new Cancion { Titulo = titulo, Duracion = duracion, ArtistaId = artistaId };
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    cancionRepository.Agregar(cancion);
    Console.WriteLine("Canción agregada exitosamente.");
    Pausar();
}

static void VerCancionesDeArtista()
{
    Console.WriteLine("Ingrese el ID del artista:");
    int artistaId = int.Parse(Console.ReadLine());
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    var canciones = cancionRepository.ObtenerTodos().Where(c => c.ArtistaId == artistaId).ToList();
    if (canciones.Count > 0)
    {
        Console.WriteLine($"Canciones del artista con ID {artistaId}:");
        foreach (var cancion in canciones)
        {
            Console.WriteLine($"- {cancion.Titulo} ({cancion.Duracion} segundos)");
        }
    }
    else
    {
        Console.WriteLine("No se encontraron canciones para este artista.");
    }
    Pausar();
}

static void MostrarCancionesMasLargas()
{
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    var canciones = cancionRepository.ObtenerTodos().OrderByDescending(c => c.Duracion).Take(5).ToList();
    if (canciones.Count > 0)
    {
        Console.WriteLine("Las 5 canciones más largas:");
        foreach (var cancion in canciones)
        {
            Console.WriteLine($"- {cancion.Titulo} ({cancion.Duracion} segundos)");
        }
    }
    else
    {
        Console.WriteLine("No se encontraron canciones.");
    }
    Pausar();
}

static void CantidadTotalDeCanciones()
{
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    int cantidad = cancionRepository.ObtenerTodos().Count;
    Console.WriteLine($"Cantidad total de canciones: {cantidad}");
    Pausar();
}

static void MostrarCancionesOrdenadasAlfabeticamente()
{
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    var canciones = cancionRepository.ObtenerTodos().OrderBy(c => c.Titulo).ToList();
    if (canciones.Count > 0)
    {
        Console.WriteLine("Canciones ordenadas alfabéticamente:");
        foreach (var cancion in canciones)
        {
            Console.WriteLine($"- {cancion.Titulo} ({cancion.Duracion} segundos)");
        }
    }
    else
    {
        Console.WriteLine("No se encontraron canciones.");
    }
    Pausar();
}

static void VerificarExistenciaDeCanciones()
{
    GenericRepository<Cancion> cancionRepository = new GenericRepository<Cancion>();
    bool existenCanciones = cancionRepository.ObtenerTodos().Any();
    if (existenCanciones)
    {
        Console.WriteLine("Existen canciones registradas.");
    }
    else
    {
        Console.WriteLine("No existen canciones registradas.");
    }
    Pausar();
}

static void Pausar()
{
    Console.WriteLine("Presione cualquier tecla para continuar...");
    Console.ReadKey();
}