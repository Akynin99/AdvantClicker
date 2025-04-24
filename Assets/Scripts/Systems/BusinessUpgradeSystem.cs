using AdvantClicker.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.Systems
{
    public class BusinessUpgradeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business, TryToUpgradeSignal> _businesses = null;
        private readonly EcsFilter<PlayerWallet> _wallet = null;
        
        public void Run()
        {
            if (_wallet.IsEmpty() || _businesses.IsEmpty()) return;
            
            ref PlayerWallet wallet = ref _wallet.Get1(0);
            
            
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);
                ref var signal = ref _businesses.Get2(i);
                int upgradeId = signal.UpgradeId;

                if (upgradeId >= business.Upgrades.Length)
                {
                    _businesses.GetEntity(i).Del<TryToUpgradeSignal>();
                    Debug.LogError("Wrong upgrade id!");
                    continue;
                }

                int upgradeCost = business.Upgrades[upgradeId].Cost;

                if (!business.Upgrades[upgradeId].IsPurchased && business.IsPurchased && wallet.Balance >= upgradeCost)
                {
                    wallet.Balance -= upgradeCost;

                    business.Upgrades[upgradeId].IsPurchased = true;
                }
                
                _businesses.GetEntity(i).Del<TryToUpgradeSignal>();
            }
        }
    }
}