using AdvantClicker.Components;

namespace AdvantClicker.Utils
{
    public static class ClickerMath
    {
        public static int CalculateIncome(Business business)
        {
            float upgradeMultiplier = 1;

            if (business.Upgrades is { Length: > 0 })
            {

                for (int i = 0; i < business.Upgrades.Length; i++)
                {
                    if (!business.Upgrades[i].IsPurchased) continue;

                    upgradeMultiplier += business.Upgrades[i].IncomeMultiplier;
                }
            }

            return CalculateIncome(business.Level, business.BaseIncome, upgradeMultiplier);
        }
        
        public static int CalculateIncome(int lvl, int baseIncome, float upgradeMultiplier)
        {
            float income = lvl * baseIncome * upgradeMultiplier;

            return (int)income;
        }

        public static int CalculateLvlUpCost(int lvl, int baseCost)
        {
            float cost = (lvl + 1) * baseCost;

            return (int)cost;
        }
    }
}