using System;

namespace ArbolBinario
{
    // Clase nodo
    class Nodo
    {
        public int Dato;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase árbol binario
    class ArbolBinarioBusqueda
    {
        public Nodo Raiz;

        public ArbolBinarioBusqueda()
        {
            Raiz = null;
        }

        // Insertar nodo
        public void Insertar(int dato)
        {
            Raiz = InsertarRec(Raiz, dato);
        }

        private Nodo InsertarRec(Nodo raiz, int dato)
        {
            if (raiz == null)
            {
                raiz = new Nodo(dato);
                return raiz;
            }

            if (dato < raiz.Dato)
                raiz.Izquierdo = InsertarRec(raiz.Izquierdo, dato);
            else if (dato > raiz.Dato)
                raiz.Derecho = InsertarRec(raiz.Derecho, dato);

            return raiz;
        }

        // Recorridos
        public void InOrden(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrden(nodo.Izquierdo);
                Console.Write(nodo.Dato + " ");
                InOrden(nodo.Derecho);
            }
        }

        public void PreOrden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Dato + " ");
                PreOrden(nodo.Izquierdo);
                PreOrden(nodo.Derecho);
            }
        }

        public void PostOrden(Nodo nodo)
        {
            if (nodo != null)
            {
                PostOrden(nodo.Izquierdo);
                PostOrden(nodo.Derecho);
                Console.Write(nodo.Dato + " ");
            }
        }

        // Buscar elemento
        public bool Buscar(int dato)
        {
            return BuscarRec(Raiz, dato);
        }

        private bool BuscarRec(Nodo raiz, int dato)
        {
            if (raiz == null)
                return false;

            if (dato == raiz.Dato)
                return true;
            else if (dato < raiz.Dato)
                return BuscarRec(raiz.Izquierdo, dato);
            else
                return BuscarRec(raiz.Derecho, dato);
        }

        // Eliminar nodo
        public void Eliminar(int dato)
        {
            Raiz = EliminarRec(Raiz, dato);
        }

        private Nodo EliminarRec(Nodo raiz, int dato)
        {
            if (raiz == null)
                return raiz;

            if (dato < raiz.Dato)
                raiz.Izquierdo = EliminarRec(raiz.Izquierdo, dato);
            else if (dato > raiz.Dato)
                raiz.Derecho = EliminarRec(raiz.Derecho, dato);
            else
            {
                // Caso 1: sin hijos
                if (raiz.Izquierdo == null && raiz.Derecho == null)
                    return null;

                // Caso 2: un hijo
                if (raiz.Izquierdo == null)
                    return raiz.Derecho;
                else if (raiz.Derecho == null)
                    return raiz.Izquierdo;

                // Caso 3: dos hijos (buscar sucesor en inorden)
                raiz.Dato = MinValor(raiz.Derecho);
                raiz.Derecho = EliminarRec(raiz.Derecho, raiz.Dato);
            }

            return raiz;
        }

        private int MinValor(Nodo nodo)
        {
            int min = nodo.Dato;
            while (nodo.Izquierdo != null)
            {
                min = nodo.Izquierdo.Dato;
                nodo = nodo.Izquierdo;
            }
            return min;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            int opcion, valor;

            do
            {
                Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO ---");
                Console.WriteLine("1. Insertar nodo");
                Console.WriteLine("2. Recorrido InOrden");
                Console.WriteLine("3. Recorrido PreOrden");
                Console.WriteLine("4. Recorrido PostOrden");
                Console.WriteLine("5. Buscar elemento");
                Console.WriteLine("6. Eliminar nodo");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor a insertar: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Insertar(valor);
                        Console.WriteLine("Nodo insertado.");
                        break;

                    case 2:
                        Console.WriteLine("Recorrido InOrden:");
                        arbol.InOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Recorrido PreOrden:");
                        arbol.PreOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("Recorrido PostOrden:");
                        arbol.PostOrden(arbol.Raiz);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Ingrese valor a buscar: ");
                        valor = int.Parse(Console.ReadLine());
                        Console.WriteLine(arbol.Buscar(valor) ? "Elemento encontrado." : "Elemento no encontrado.");
                        break;

                    case 6:
                        Console.Write("Ingrese valor a eliminar: ");
                        valor = int.Parse(Console.ReadLine());
                        arbol.Eliminar(valor);
                        Console.WriteLine("Nodo eliminado (si existía).");
                        break;

                    case 7:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 7);
        }
    }
}
