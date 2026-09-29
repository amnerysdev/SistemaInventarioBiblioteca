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
                if (!short.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = -1;
                }
                switch (opcion)
                {
                    case 1:
                        MostrarInventario();
                        break;
                    case 2:
                        ConsultarDisponibilidad();
                        break;
                    case 3:
                        ActualizarDisponibilidad();
                        break;
                    case 4:
                        TotalDeUnLibro();
                        break;
                    case 5:
                        TotalDeUnaSucursal();
                        break;
                    case 6:
                        MostrarBajoInventario();
                        break;
                    case 7:
                        SucursalConMayorDisponibilidad();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
                        Console.ReadKey();
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
        // 1. Mostrar inventario completo
        // Complejidad: O(n * m) -- Para desplegar todos los elementos del inventario,
        // se recorre cada libro (n) y cada sucursal (m) para mostrar la cantidad disponible.
        // 5 x 3 = 15 elementos en total, lo que es igual a n * m.
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

        // ---------------------------------------------------------
        // 2. Consultar disponibilidad de un libro
        // Complejidad: O(1) -- Se accede directamente a la posición
        // del libro y sucursal en el arreglo, lo que toma tiempo constante.
        // ---------------------------------------------------------
        static void ConsultarDisponibilidad()
        {
            Console.Clear();
            Console.WriteLine("====== CONSULTAR DISPONIBILIDAD ======\n");

            int libro;
            Console.Write("Ingrese el número del libro (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out libro) || libro < 1 || libro > inventario.GetLength(0))
            {
                Console.Write("Entrada inválida. Ingrese el número del libro (1-5): ");
            }
            libro--;

            int sucursal;
            Console.Write("Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            while (!int.TryParse(Console.ReadLine(), out sucursal) || sucursal < 1 || sucursal > inventario.GetLength(1))
            {
                Console.Write("Entrada inválida. Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            }
            sucursal--;

            Console.WriteLine($"\n'Libro {libro + 1}' en la sucursal {sucursal + 1}: {inventario[libro, sucursal]} unidad(es).");

            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }

        // ---------------------------------------------------------
        // 3. Actualizar disponibilidad de un libro
        // Complejidad: O(1) -- Se actualiza directamente la cantidad en
        // la posición del libro y sucursal en el arreglo, lo que toma tiempo constante.
        // ---------------------------------------------------------
        static void ActualizarDisponibilidad()
        {
            Console.Clear();
            Console.WriteLine("====== ACTUALIZAR DISPONIBILIDAD ======\n");

            int libro;
            Console.Write("Ingrese el número del libro (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out libro) || libro < 1 || libro > inventario.GetLength(0))
            {
                Console.Write("Entrada inválida. Ingrese el número del libro (1-5): ");
            }
            libro--;

            int sucursal;
            Console.Write("Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            while (!int.TryParse(Console.ReadLine(), out sucursal) || sucursal < 1 || sucursal > inventario.GetLength(1))
            {
                Console.Write("Entrada inválida. Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            }
            sucursal--;

            int nuevaCantidad;
            Console.Write("Ingrese la nueva cantidad disponible: ");
            while (!int.TryParse(Console.ReadLine(), out nuevaCantidad) || nuevaCantidad < 0)
            {
                Console.Write("Entrada inválida. Ingrese la nueva cantidad disponible (0 o más): ");
            }

            inventario[libro, sucursal] = nuevaCantidad;
            Console.WriteLine($"\nDisponibilidad actualizada: 'Libro {libro + 1}' en la sucursal {sucursal + 1} ahora tiene {nuevaCantidad} unidad(es).");

            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }

        // ---------------------------------------------------------
        // 4. Total de un libro
        // Complejidad: O(m) -- Se recorre cada sucursal (m) para sumar
        // la cantidad disponible del libro, lo que toma tiempo lineal
        // respecto al número de sucursales.
        // ---------------------------------------------------------
        static void TotalDeUnLibro()
        {
            Console.Clear();
            Console.WriteLine("====== TOTAL DISPONIBLE DE UN LIBRO ======\n");

            int libro;
            Console.Write("Ingrese el número del libro (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out libro) || libro < 1 || libro > inventario.GetLength(0))
            {
                Console.Write("Entrada inválida. Ingrese el número del libro (1-5): ");
            }
            libro--;

            int total = 0;
            for (int j = 0; j < inventario.GetLength(1); j++)
            {
                total += inventario[libro, j];
            }
            Console.WriteLine($"\nTotal disponible de 'Libro {libro + 1}': {total} unidad(es).");
            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }
        // ---------------------------------------------------------
        // 5. Total de una Sucursal
        // Complejidad: O(n) -- Se recorre cada libro (n) para sumar la
        // cantidad disponible en la sucursal, lo que toma tiempo lineal
        // respecto al número de libros.
        // ---------------------------------------------------------
        static void TotalDeUnaSucursal()
        {
            Console.Clear();
            Console.WriteLine("====== TOTAL DE INVENTARIO POR SUCURSAL ======\n");

            int sucursal;
            Console.Write("Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            while (!int.TryParse(Console.ReadLine(), out sucursal) || sucursal < 1 || sucursal > inventario.GetLength(1))
            {
                Console.Write("Entrada inválida. Ingrese el número de la sucursal (1-Centro, 2-Norte, 3-Sur): ");
            }
            sucursal--;

            int total = 0;
            for (int i = 0; i < inventario.GetLength(0); i++)
            {
                total += inventario[i, sucursal];
            }
            Console.WriteLine($"\nTotal disponible en la sucursal {sucursal + 1}: {total} unidad(es).");
            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }

        // ---------------------------------------------------------
        // 6. Mostrar libros con bajo inventario
        // Complejidad: O(n * m) -- Para mostrar los libros con bajo inventario,
        // se recorre cada libro (n) y cada sucursal (m) para verificar si
        // la cantidad es menor o igual a 3. 
        // ---------------------------------------------------------
        static void MostrarBajoInventario()
        {
            Console.Clear();
            Console.WriteLine("====== LIBROS CON BAJO INVENTARIO ======\n");

            bool hayBajoInventario = false;

            for (int i = 0; i < inventario.GetLength(0); i++)
            {
                for (int j = 0; j < inventario.GetLength(1); j++)
                {
                    if (inventario[i, j] <= 3)
                    {
                        Console.WriteLine($"Libro {i + 1} | Sucursal {j + 1}: {inventario[i, j]} unidad(es)");
                        hayBajoInventario = true;
                    }
                }
            }

            if (!hayBajoInventario)
            {
                Console.WriteLine("No hay libros con bajo inventario.");
            }

            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }
        // ---------------------------------------------------------
        // 7. Sucursal con mayor disponibilidad
        // Complejidad: O(m) -- hay que recorrer todas las sucursales (m)
        // para encontrar la que tiene la mayor disponibilidad del libro especificado.
        // ---------------------------------------------------------
        static void SucursalConMayorDisponibilidad()
        {
            Console.Clear();
            Console.WriteLine("====== SUCURSAL CON MAYOR DISPONIBILIDAD ======\n");

            int libro;
            Console.Write("Ingrese el número del libro (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out libro) || libro < 1 || libro > inventario.GetLength(0))
            {
                Console.Write("Entrada inválida. Ingrese el número del libro (1-5): ");
            }
            libro--;

            int mejor = 0;
            for (int c = 1; c < inventario.GetLength(1); c++)
            {
                if (inventario[libro, c] > inventario[libro, mejor])
                    mejor = c;
            }
            Console.WriteLine($"Libro {libro + 1} | Sucursal {mejor + 1}: {inventario[libro, mejor]} unidad(es)");


            Console.WriteLine("\nPuedes presionar cualquier tecla para continuar :)");
            Console.ReadKey();
        }
    }
}