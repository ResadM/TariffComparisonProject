using TariffComparison.Models;

namespace TariffComparison
{
    public static class TariffCalculation
    {
        public static decimal CalculateAnnualCostForProductA(decimal consumption)
        {
            //Declaring base costs rate and consumption costs rate
            decimal baseCost = 5;
            decimal consumptionCost = 0.22M;

            //Calculating base costs total and consumption costs total
            decimal baseCostTotal = baseCost * 12;
            decimal consumptionCostTotal = consumptionCost * consumption;

            //Calculating annual costs
            return baseCostTotal+ consumptionCostTotal;
        }

        public static decimal CalculateAnnualCostForProductB(decimal consumption)
        {
            //Declaring consumption limit (kWh/year)
            decimal consumptionLimit = 4000;

            //Declaring consumption under limit cost
            decimal consumptionUnderLimitCost = 800;

            //Declaring consumption over limit cost
            decimal consumptionOverLimitCost = 0.30M;

            //If consumption is lower or equal to consumption limit, then retun 800 (under limit cost)
            if(consumption<=consumptionLimit) 
                return consumptionUnderLimitCost;

            //Calculating consumption remaining after limit
            decimal consumptionRemain=consumption-consumptionLimit;

            //Calculating consumption total of over limit
            decimal consumptionCostTotal = consumptionRemain * consumptionOverLimitCost;

            return consumptionCostTotal + consumptionUnderLimitCost;
        }

        public static List<Tariff> CompareTariffs(decimal consumption)
        {
            List<Tariff> tariffs = new List<Tariff>
            {
                new Tariff{ TariffName="Basic electricity tariff",AnnualCosts=CalculateAnnualCostForProductA(consumption)},
                 new Tariff{TariffName="Packaged tarif",AnnualCosts=CalculateAnnualCostForProductB(consumption) }
            };

            return tariffs.OrderBy(t=>t.AnnualCosts).ToList();
        }
    }
}
