using System;
using System.Collections.Generic;

public class CatalogoRevistas
{
    private List<string> catalogo;

    public CatalogoRevistas()
    {
        // Inicializa el catálogo con al menos 10 títulos de revistas.
        catalogo = new List<string>
        {
            "National Geographic",
            "Scientific American",
            "Time Magazine",
            "The New Yorker",
            "Vogue",
            "Forbes",
            "Wired",
            "Cosmopolitan",
            "Sports Illustrated",
            "The Economist"
        };
    }

    /// <summary>
    /// Busca un título de revista de forma iterativa en el catálogo.
    /// </summary>
    /// <param name="titulo">El título a buscar.</param>
    /// <returns>Verdadero si se encuentra el título, falso en caso contrario.</returns>
    public bool BuscarTituloIterativo(string titulo)
    {
        // Realiza una búsqueda insensible a mayúsculas y minúsculas para una mejor experiencia de usuario.
        string tituloLower = titulo.ToLower();

        foreach (var revista in catalogo)
        {
            if (revista.ToLower() == tituloLower)
            {
                return true; // Título encontrado.
            }
        }
        return false; // Título no encontrado.
    }

    /// <summary>
    /// Muestra el menú de opciones al usuario y maneja la entrada.
    /// </summary>
    public void MostrarMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título de revista");
            Console.WriteLine("2. Salir");
            Console.Write("Por favor, ingrese su opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string titulo = Console.ReadLine();
                    string resultado = BuscarTituloIterativo(titulo) ? "Encontrado" : "No encontrado";
                    Console.WriteLine($"\nResultado de la búsqueda: {resultado}");
                    break;
                case "2":
                    salir = true;
                    Console.WriteLine("Saliendo del programa. ¡Gracias por usarlo!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    public static void Main(string[] args)
    {
        CatalogoRevistas app = new CatalogoRevistas();
        app.MostrarMenu();
    }
}
