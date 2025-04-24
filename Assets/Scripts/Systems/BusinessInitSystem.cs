using Leopotam.Ecs;
using AdvantClicker.Components;
using AdvantClicker.Config;
using AdvantClicker.MonoBehaviours;
using AdvantClicker.Utils;

namespace AdvantClicker.Systems
{
    // Initializes businesses from configuration and save files
    public class BusinessInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly GameConfig _gameConfig = null;
        private readonly NamesConfig _namesConfig = null;
        private readonly MainUIScreen _mainUIScreen = null;

        public void Init()
        {
            foreach (var businessConfig in _gameConfig.Businesses)
            {
                // Create entity for each business in config
                var entity = _world.NewEntity();
                
                // Add business component
                ref var business = ref entity.Get<Business>();
                
                // get static variables from config
                business.SaveId = businessConfig.SaveId;
                business.Name = _namesConfig.GetName(businessConfig.NameId);
                business.IncomeGenerationTime = businessConfig.IncomeGenerationTime;
                business.BaseIncome = businessConfig.BaseIncome;
                business.BaseLevelUpCost = businessConfig.BaseLevelUpCost;

                // try load dynamic variables from save
                if (SaveHelper.BusinessSaveExists(business.SaveId))
                {
                    // save exists - load from save
                    LoadValuesFromSave(ref business, businessConfig);
                }
                else
                {
                    // no save - load from config
                    InitDefaultValues(ref business, businessConfig);
                }
            }
        }

        private void LoadValuesFromSave(ref Business business, BusinessConfig businessConfig)
        {
            var saveData = SaveHelper.Load(businessConfig.SaveId);
            business.Level = saveData.Level;
            business.IsPurchased = business.Level > 0;
            business.Progress = saveData.Progress;
            
            business.Upgrades = new BusinessUpgrade[businessConfig.AvailableUpgrades.Count];

            for (var i = 0; i < businessConfig.AvailableUpgrades.Count; i++)
            {
                var upgradeConfig = businessConfig.AvailableUpgrades[i];

                business.Upgrades[i] = new BusinessUpgrade()
                {
                    IsPurchased = saveData.Upgrades[i],
                    Id = i,
                    Name = _namesConfig.GetName(upgradeConfig.NameId),
                    Cost = upgradeConfig.Cost,
                    IncomeMultiplier = upgradeConfig.IncomeMultiplier
                };
            }
        }

        private void InitDefaultValues(ref Business business, BusinessConfig businessConfig)
        {
            business.Level = businessConfig.StartingBusiness ? 1 : 0;
            business.IsPurchased = businessConfig.StartingBusiness;
            business.Progress = 0;
            
            business.Upgrades = new BusinessUpgrade[businessConfig.AvailableUpgrades.Count];

            for (var i = 0; i < businessConfig.AvailableUpgrades.Count; i++)
            {
                var upgradeConfig = businessConfig.AvailableUpgrades[i];

                business.Upgrades[i] = new BusinessUpgrade()
                {
                    IsPurchased = false,
                    Id = i,
                    Name = _namesConfig.GetName(upgradeConfig.NameId),
                    Cost = upgradeConfig.Cost,
                    IncomeMultiplier = upgradeConfig.IncomeMultiplier
                };
            }
        }
    }
} 