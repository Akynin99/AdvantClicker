using AdvantClicker.Components;
using AdvantClicker.Utils;
using Leopotam.Ecs;

namespace AdvantClicker.Systems
{
    public class BusinessLevelUpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business, TryToLevelUpBusinessSignal> _businesses = null;
        private readonly EcsFilter<PlayerWallet> _wallet = null;
        
        public void Run()
        {
            if (_wallet.IsEmpty() || _businesses.IsEmpty()) return;
            
            ref PlayerWallet wallet = ref _wallet.Get1(0);
            
            
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);

                int lvlUpCost = ClickerMath.CalculateLvlUpCost(business.Level, business.BaseLevelUpCost);

                if (wallet.Balance >= lvlUpCost)
                {
                    wallet.Balance -= lvlUpCost;
                    
                    if (business.IsPurchased)
                    {
                        business.Level += 1;
                    }
                    else
                    {
                        business.IsPurchased = true;
                        business.Level = 1;
                    }
                    
                }
                
                _businesses.GetEntity(i).Del<TryToLevelUpBusinessSignal>();
            }
        }
    }
}