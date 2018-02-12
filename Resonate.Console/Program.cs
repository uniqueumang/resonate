using System;
using Microsoft.Extensions.DependencyInjection;
using Resonate.BusinessService.Interface;
using Resonate.DI;

namespace Resonate.Console

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Setup();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            System.Console.WriteLine("Press 1 to see Schema");
            System.Console.WriteLine("Press 2 to see Filtered Result Set");

            var dataService = serviceProvider.GetService<IDataService>();
            switch (int.Parse(System.Console.ReadLine()))
            {
                case 1:
                    ExecuteGetSchema(dataService);
                    break;
                case 2:
                    ExecuteGetFilteredResults(dataService);
                    break;
                default:
                    System.Console.WriteLine("Incorrect number entered");
                    break;
            }

            System.Console.WriteLine("\n\nExiting. Press any key to exit");
            System.Console.ReadLine();
        }

        private static void ExecuteGetSchema(IDataService dataService)
        {
            foreach (var schemaResult in dataService.GetSchema())
                System.Console.WriteLine($"{schemaResult.Key} {schemaResult.Value}");
        }

        private static void ExecuteGetFilteredResults(IDataService dataService)
        {
            System.Console.WriteLine("Enter name of the column to filter result on:");
            var columnName = System.Console.ReadLine();
            var filteredValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(columnName))
            {
                System.Console.WriteLine("Enter value:");
                filteredValue = System.Console.ReadLine();
            }
            try
            {
                var results = dataService.GetResultsByColumnFilter(columnName, filteredValue);
                foreach (var result in results)
                    System.Console.WriteLine(
                        $"{result.Id} {result.Name} {result.DoB:dd/MM/yyyy}");
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e.Message);
            }
        }
    }
}