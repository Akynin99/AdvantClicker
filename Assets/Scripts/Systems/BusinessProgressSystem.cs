using Leopotam.Ecs;
using UnityEngine;
using AdvantClicker.Components;

namespace AdvantClicker.Systems
{
    // Updates the income generation progress for purchased businesses
    public class BusinessProgressSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business> _businesses = null;

        public void Run()
        {
            float deltaTime = Time.deltaTime;
            
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);
                
                // Only update progress for purchased businesses
                if (business.IsPurchased)
                {
                    // Increment progress
                    business.Progress += deltaTime / business.IncomeGenerationTime;
                }
            }
        }
    }
} 