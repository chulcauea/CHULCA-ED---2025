using System;

namespace SistemaEstudiantes
{
    // Clase Estudiante con atributos y métodos
    class Estudiante
    {
        // Propiedades públicas
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } = new string[3];

        // Constructor sin parámetros
        public Estudiante() {}

        // Constructor con parámetros
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para imprimir los datos del estudiante
        public void Imprimir()
        {
            Console.WriteLine("===== INFORMACIÓN DEL ESTUDIANTE =====");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos registrados:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    // Clase principal que contiene el método Main
    class Programa
    {
        static void Main(string[] args)
        {
            // Crear array de teléfonos
            string[] telefonos = new string[] { "0965432101", "042233445", "0933344556" };

            // Crear instancia del estudiante con datos de prueba
            Estudiante estudiante = new Estudiante(
                101,
                "Carlos Andrés",
                "Mendoza Loor",
                "Calle Bolívar y Rocafuerte, Baba",
                telefonos
            );

            // Mostrar datos del estudiante
            estudiante.Imprimir();

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}