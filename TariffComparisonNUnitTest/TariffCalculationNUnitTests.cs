using NUnit.Framework;
using TariffComparison.Models;


namespace TariffComparison
{
    [TestFixture]
    public class TariffCalculationNUnitTests
    {
        [Test]
        [TestCase(3500, ExpectedResult = 830)]
        [TestCase(4500, ExpectedResult = 1050)]
        [TestCase(6000, ExpectedResult = 1380)]
        public decimal Test_CalculateAnnualCostForProductA(decimal consumption)
        {
            return TariffCalculation.CalculateAnnualCostForProductA(consumption);
        }

        [Test]
        [TestCase(3500, ExpectedResult = 800)]
        [TestCase(4500, ExpectedResult = 950)]
        [TestCase(6000, ExpectedResult = 1400)]
        public decimal Test_CalculateAnnualCostForProductB(decimal consumption)
        {
            return TariffCalculation.CalculateAnnualCostForProductB(consumption);
        }

        [Test]
        [TestCase(3500)]
        public void Test_CompareTariffs(decimal consumption)
        {
            //Act
            List<Tariff> tariffs = TariffCalculation.CompareTariffs(consumption);

            //Assert
            Assert.That(tariffs.Count, Is.EqualTo(2));// Ensure that all two tariffs are returned

            //Assuming CalculateAnnualCostForProductA and CalculateAnnualCostForProductB methods are correct and returning expected values
            Assert.That(tariffs[0].TariffName, Is.EqualTo("Packaged tarif"));
            Assert.That(tariffs[0].AnnualCosts, Is.EqualTo(800));

            Assert.That(tariffs[1].TariffName, Is.EqualTo("Basic electricity tariff"));
            Assert.That(tariffs[1].AnnualCosts, Is.EqualTo(830));
        }
        [Test]
        [TestCase(3500, "Packaged tarif", 800)]
        [TestCase(4500, "Packaged tarif", 950)]
        [TestCase(6000, "Basic electricity tariff", 1380)]
        public void Test_CompareTariffs_With_ExpectedValues(decimal consumption, string expectedTariffName, decimal expectedAnnualCost)
        {
            //Act
            List<Tariff> tariffs = TariffCalculation.CompareTariffs(consumption);

            //Assert
            Assert.That(tariffs.Count, Is.EqualTo(2));// Ensure that all two tariffs are returned

            //Check if first row of tariff returns expected values
            Assert.That(tariffs[0].TariffName, Is.EqualTo(expectedTariffName));
            Assert.That(tariffs[0].AnnualCosts, Is.EqualTo(expectedAnnualCost));
        }
    }
}