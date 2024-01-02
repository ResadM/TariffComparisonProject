// See https://aka.ms/new-console-template for more information
using TariffComparison;
using TariffComparison.Models;

Console.WriteLine("Tariff Comparison");

Console.WriteLine("Enter Consumption (kWh/year): ");
if (decimal.TryParse(Console.ReadLine(), out decimal consumption))
{
    List<Tariff> comparedTariffs = TariffCalculation.CompareTariffs(consumption);
    Console.WriteLine("Consumption (kWh/year)\tTariff Name\t\t\tAnnual Costs (Euro/year)");

    foreach (var tariff in comparedTariffs)
    {
        Console.WriteLine($"{consumption}\t\t\t{tariff.TariffName}\t\t\t{tariff.AnnualCosts}");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number for consumption.");
}


//Compare Consumption from dummy data
Console.WriteLine("\n");
List<decimal> dummyData = new List<decimal>();
Random rnd = new Random();
for (int i = 0; i < 20; i++)
{
    dummyData.Add(rnd.Next(1000, 9999));
}

Console.WriteLine("Tariff Comparison from Dummy Data");
Console.WriteLine("Consumption (kWh/year)\tTariff Name\t\t\tAnnual Costs (Euro/year)");

foreach (var data in dummyData)
{
    Console.WriteLine("--------------------------------------------------------------");
    List<Tariff> comparedTariffs = TariffCalculation.CompareTariffs(data);
    foreach (var tariff in comparedTariffs)
    {
        Console.WriteLine($"{data}\t\t\t{tariff.TariffName}\t\t\t{tariff.AnnualCosts}");
    }
}
