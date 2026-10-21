using System;

namespace Biblioteca
{
    // Clase que representa un libro del catálogo
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(int id, string title, string author, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return "[" + Id + "] " + Title + " - " + Author + " (" + Year + ")";
        }
    }

    class Program
    {
        // Almacenamiento principal: arreglo de capacidad 20
        static Book[] books = new Book[20];
        // Cantidad de posiciones realmente ocupadas
        static int count = 0;
        // Contador de comparaciones de la última búsqueda
        static int comparisons = 0;
        // Si es true, imprime la traza de cada iteración
        static bool showTrace = false;

        // Registra un libro al final (el catálogo se carga en orden ascendente de ID)
        static bool AddBook(Book b)
        {
            if (count >= books.Length) return false;
            books[count] = b;
            count++;
            return true;
        }

        static void LoadCatalog()
        {
            AddBook(new Book(10, "Clean Code", "Robert C. Martin", 2008));
            AddBook(new Book(20, "The Pragmatic Programmer", "Andrew Hunt", 1999));
            AddBook(new Book(30, "Design Patterns", "Erich Gamma", 1994));
            AddBook(new Book(40, "Refactoring", "Martin Fowler", 1999));
            AddBook(new Book(50, "Clean Architecture", "Robert C. Martin", 2017));
            AddBook(new Book(60, "Domain-Driven Design", "Eric Evans", 2003));
            AddBook(new Book(70, "Algorithms", "Robert Sedgewick", 1983));
            AddBook(new Book(80, "Introduction to Algorithms", "Thomas H. Cormen", 1990));
            AddBook(new Book(90, "Code Complete", "Steve McConnell", 1993));
            AddBook(new Book(100, "Working Effectively with Legacy Code", "Michael Feathers", 2004));
        }

        // Búsqueda binaria manual sobre las primeras 'count' posiciones.
        // Devuelve el libro encontrado o null. Actualiza el contador 'comparisons'.
        static Book BinarySearchById(Book[] arr, int n, int id)
        {
            comparisons = 0;
            int left = 0;
            int right = n - 1;
            int iteration = 0;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int midId = arr[middle].Id;
                comparisons++;          // un elemento central examinado
                iteration++;

                if (showTrace)
                {
                    string decision;
                    if (midId == id) decision = "Encontrado";
                    else if (id < midId) decision = "Buscar a la izquierda (right = middle - 1)";
                    else decision = "Buscar a la derecha (left = middle + 1)";
                    Console.WriteLine("  Iter " + iteration + ": left=" + left + ", right=" + right +
                                      ", middle=" + middle + ", ID central=" + midId + " -> " + decision);
                }

                if (midId == id) return arr[middle];
                if (id < midId) right = middle - 1;
                else left = middle + 1;
            }
            return null; // no existe
        }

        static void SearchAndShow(int id)
        {
            Book result = BinarySearchById(books, count, id);
            Console.WriteLine("Buscando ID " + id + ":");
            if (result != null)
                Console.WriteLine("  Resultado: ENCONTRADO -> " + result);
            else
                Console.WriteLine("  Resultado: NO ENCONTRADO (el libro no existe en el catálogo)");
            Console.WriteLine("  Comparaciones: " + comparisons);
            Console.WriteLine();
        }

        static void RunTestCases()
        {
            int[] ids = { 10, 50, 70, 100, 999 };
            string[] names = { "Primer libro", "Zona central", "Libro intermedio", "Último libro", "No existe" };
            Console.WriteLine("=== CASOS DE PRUEBA (con traza) ===");
            Console.WriteLine();
            showTrace = true;
            for (int i = 0; i < ids.Length; i++)
            {
                Console.WriteLine("Caso: " + names[i]);
                SearchAndShow(ids[i]);
            }
            showTrace = false;

            Console.WriteLine("=== TABLA RESUMEN ===");
            Console.WriteLine("ID\tCaso\t\t\t¿Encontrado?\tComparaciones");
            for (int i = 0; i < ids.Length; i++)
            {
                Book r = BinarySearchById(books, count, ids[i]);
                Console.WriteLine(ids[i] + "\t" + names[i] + "\t\t" + (r != null ? "Sí" : "No") + "\t\t" + comparisons);
            }
        }

        static void ListBooks()
        {
            Console.WriteLine("Catálogo (" + count + " de " + books.Length + " posiciones ocupadas):");
            for (int i = 0; i < count; i++)
                Console.WriteLine("  " + i + ": " + books[i]);
        }

        static void Main(string[] args)
        {
            LoadCatalog();

            if (args.Length > 0 && args[0] == "--test")
            {
                RunTestCases();
                return;
            }

            int option = -1;
            while (option != 0)
            {
                Console.WriteLine("===== BIBLIOTECA =====");
                Console.WriteLine("1. Listar libros");
                Console.WriteLine("2. Buscar libro por ID (binaria)");
                Console.WriteLine("3. Ejecutar casos de prueba");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                string line = Console.ReadLine();
                if (line == null) break;
                if (!int.TryParse(line, out option)) { option = -1; Console.WriteLine("Opción inválida.\n"); continue; }

                if (option == 1) ListBooks();
                else if (option == 2)
                {
                    Console.Write("ID a buscar: ");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id)) SearchAndShow(id);
                    else Console.WriteLine("ID inválido.\n");
                }
                else if (option == 3) RunTestCases();
            }
        }
    }
}