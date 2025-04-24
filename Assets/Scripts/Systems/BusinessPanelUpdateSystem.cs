using AdvantClicker.Components;
using AdvantClicker.Utils;
using Leopotam.Ecs;

namespace AdvantClicker.Systems
{
    public class BusinessPanelUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business, BusinessView> _businesses = null;
        
        public void Run()
        {
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);
                ref var view = ref _businesses.Get2(i);
                
                view.BusinessPanel.UpdateProgress(business.Progress);
                view.BusinessPanel.UpdateLevel(business.Level);
                int income = ClickerMath.CalculateIncome(business);
                view.BusinessPanel.UpdateIncome(income);
                int lvlUpPrice = ClickerMath.CalculateLvlUpCost(business.Level, business.BaseLevelUpCost);
                view.BusinessPanel.UpdateLvlUpPrice(lvlUpPrice);
                view.BusinessPanel.UpdateUpgradeButtons(business.Upgrades);
            }
        }
    }
}