using System;

namespace SistemaInventarioBiblioteca
{
    class Program
    {
        static int[,] inventario = {
            //  Centro Norte Sur
            {   5,     2,    8 },   // Libro 1
            {   1,     0,    4 },   // Libro 2
            {   7,     6,    3 },   // Libro 3
            {   2,     9,    1 },   // Libro 4
            {   4,     4,   10 }    // Libro 5

        };
        static void Main(string[] args)
        {
            short opcion;

            do
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt16(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        MostrarInventario();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            } while (opcion != 0);



        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("====== INVENTARIO POR SUCURSAL ======\n");
            Console.WriteLine("1. Mostrar inventario completo");
            Console.WriteLine("2. Consultar disponibilidad");
            Console.WriteLine("3. Actualizar disponibilidad");
            Console.WriteLine("4. Total disponible de un libro");
            Console.WriteLine("5. Total de inventario por sucursal");
            Console.WriteLine("6. Mostrar libros con bajo inventario");
            Console.WriteLine("7. Sucursal con mayor disponibilidad");
            Console.WriteLine("0. Salir\n");

        }

        // ---------------------------------------------------------
        // 1. Mosrtrar inventario completo
        // Complejidad: O(n * m) -- Para desplegar todos los elementos del inventario,
        // se recorre cada libro (n) y cada sucursal (m) para mostrar la cantidad disponible.
        // 3 x 5 = 15 elementos en total, lo que es igual a n * m.
        // ---------------------------------------------------------
        static void MostrarInventario()
        {
            Console.Clear();
            Console.WriteLine("====== INVENTARIO COMPLETO ======\n");
            Console.WriteLine("Libro\tCentro\tNorte \tSur");
            for (int i = 0; i < inventario.GetLength(0); i++)
            {
                Console.Write($"Libro {i + 1}\t");
                for (int j = 0; j < inventario.GetLength(1); j++)
                {
                    Console.Write($"{inventario[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }
}
}
