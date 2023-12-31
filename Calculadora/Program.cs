using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Calculadora Funcional");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PerformOperation(GetNumbersFromUser, numbers => numbers.Sum(), "Suma");
                    break;
                case "2":
                    PerformOperation(GetNumbersFromUser, numbers => numbers.Aggregate((x, y) => x - y), "Resta");
                    break;
                case "3":
                    PerformOperation(GetNumbersFromUser, numbers => numbers.Aggregate((x, y) => x * y), "Multiplicación");
                    break;
                case "4":
                    PerformOperation(GetNumbersFromUser, numbers => numbers.Aggregate((x, y) => x / y), "División");
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static List<double> GetNumbersFromUser()
    {
        Console.Write("Ingrese los números separados por espacio: ");
        string input = Console.ReadLine();
        return input.Split(' ').Select(double.Parse).ToList();
    }

    static void PerformOperation(Func<List<double>> inputFunc, Func<List<double>, double> operationFunc, string operationName)
    {
        List<double> numbers = inputFunc();
        double result = operationFunc(numbers);
        Console.WriteLine($"{operationName}: {result}\n");
    }
}