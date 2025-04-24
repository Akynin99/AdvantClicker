using System;
using AdvantClicker.Components;
using AdvantClicker.Config;
using AdvantClicker.Utils;
using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.Systems
{
    public class BusinessSaveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Business> _businesses = null;
        private readonly GameConfig _gameConfig = null;
        
        public void Run()
        {
            foreach (var i in _businesses)
            {
                ref var business = ref _businesses.Get1(i);
                
                if (_businesses.GetEntity(i).Has<BusinessSaveData>())
                {
                    // save data component already exists
                    ref var saveData = ref _businesses.GetEntity(i).Get<BusinessSaveData>();
                    
                    saveData.Level = business.Level;
                    saveData.Progress = business.Progress;
                    
                    for (int j = 0; j < saveData.Upgrades.Length; j++)
                    {
                        saveData.Upgrades[j] = business.Upgrades[j].IsPurchased;
                    }

                    // save data on cooldown or every frame (configured in config)
                    if (_gameConfig.SavingEveryFrame || _gameConfig.SavingCooldown <= Time.time - saveData.LastSaveTime)
                    {
                        SaveHelper.SaveData(saveData);
                        saveData.LastSaveTime = Time.time;
                    }
                }
                else
                {
                    // create new save data component and save it
                    ref var saveData = ref _businesses.GetEntity(i).Get<BusinessSaveData>();
                    saveData.SaveId = business.SaveId;
                    
                    saveData.Level = business.Level;
                    saveData.Progress = business.Progress;
                    saveData.Upgrades = new bool[business.Upgrades.Length];
                    
                    for (int j = 0; j < saveData.Upgrades.Length; j++)
                    {
                        saveData.Upgrades[j] = business.Upgrades[j].IsPurchased;
                    }
                    
                    // save it
                    SaveHelper.SaveData(saveData);
                    saveData.LastSaveTime = Time.time;
                }
            }
        }
    }
}