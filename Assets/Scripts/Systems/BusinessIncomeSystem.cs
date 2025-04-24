using Leopotam.Ecs;
using UnityEngine;
using AdvantClicker.Components;
using AdvantClicker.Utils;

namespace AdvantClicker.Systems
{
    // Credits income when progress reaches maximum
    public class BusinessIncomeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business> _businesses = null;
        private readonly EcsFilter<PlayerWallet> _wallet = null;

        public void Run()
        {
            if (_wallet.IsEmpty()) return;
            
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);
                
                // Only process purchased businesses with full progress
                if (business.IsPurchased && business.Progress >= 1.0f)
                {
                    // Reset progress
                    business.Progress -= 1;

                    int income = ClickerMath.CalculateIncome(business);
                    
                    AddIncomeToWallet(income);
                }
            }
        }

        private void AddIncomeToWallet(int income)
        {
            foreach (var i in _wallet)
            {
                ref var wallet = ref _wallet.Get1(i);
                wallet.Balance += income;
            }
        }
    }
} 