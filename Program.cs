using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        List<string> estudiantes = new List<string>();
        List<double> calificaciones = new List<double>();

        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        while (true)
        {
            ShowLoadingIcon();
            Console.Clear();

            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Mostrar lista de estudiantes");
            Console.WriteLine("3. Calcular promedio de calificaciones");
            Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                Console.WriteLine("Opción no válida, por favor ingrese una opción entre 1 y 5.");
                Console.Write("Seleccione una opción: ");
            }

            ShowLoadingIcon();

            if (opcion == 1)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("           Agregar estudiante");
                Console.WriteLine("----------------------------------------");

                Console.Write("Ingrese el nombre del estudiante: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("----------------------------------------");

                Console.Write("Ingrese la calificación del estudiante: ");
                double calificacion;
                while (!double.TryParse(Console.ReadLine(), out calificacion) || calificacion < 0 || calificacion > 10)
                {
                    Console.Write("Calificación no válida. Ingrese un número entre 0 y 10: ");
                }
                Console.WriteLine("----------------------------------------");

                estudiantes.Add(nombre);
                calificaciones.Add(calificacion);
                Console.WriteLine("Estudiante agregado correctamente.");
            }
            else if (opcion == 2)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("     Mostrar lista de estudiantes");
                Console.WriteLine("----------------------------------------");

                if (estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados.");
                }
                else
                {
                    Console.WriteLine("\nLista de estudiantes:");
                    for (int i = 0; i < estudiantes.Count; i++)
                    {
                        Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
                    }
                }
            }
            else if (opcion == 3)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("     Calcular promedio de calificaciones");
                Console.WriteLine("----------------------------------------");

                if (calificaciones.Count == 0)
                {
                    Console.WriteLine("No hay calificaciones registradas.");
                }
                else
                {
                    double suma = 0;
                    foreach (double calificacion in calificaciones)
                    {
                        suma += calificacion;
                    }
                    double promedio = suma / calificaciones.Count;
                    Console.WriteLine($"El promedio de calificaciones es: {promedio}");
                }
            }
            else if (opcion == 4)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("     Mostrar estudiante con la calificación más alta");
                Console.WriteLine("----------------------------------------");

                if (calificaciones.Count == 0)
                {
                    Console.WriteLine("No hay calificaciones registradas.");
                }
                else
                {
                    double maxCalificacion = calificaciones[0];
                    string estudianteMax = estudiantes[0];
                    for (int i = 1; i < calificaciones.Count; i++)
                    {
                        if (calificaciones[i] > maxCalificacion)
                        {
                            maxCalificacion = calificaciones[i];
                            estudianteMax = estudiantes[i];
                        }
                    }
                    Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
                }
            }
            else if (opcion == 5)
            {
                Console.WriteLine("Saliendo del sistema...");
                break;
            }

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal...");
            Console.ReadKey();
            ShowLoadingIcon();
            Console.Clear();
        }
    }

    static void ShowLoadingIcon()
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int count = 0;
        for (int i = 0; i < 10; i++)  
        {
            Console.SetCursorPosition(0, Console.CursorTop);  
            Console.Write(spinner[count % 4]);  
            Thread.Sleep(200);  
            count++;
        }
        Console.SetCursorPosition(0, Console.CursorTop);  
        Console.Write(" ");  
    }
}

