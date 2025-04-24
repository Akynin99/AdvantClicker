using System.Collections.Generic;
using UnityEngine;

namespace AdvantClicker.Config
{
    // ScriptableObject for configuring business parameters
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "Config/Business")]
    public class BusinessConfig : ScriptableObject
    {
        [Header("Identifiers")]
        [SerializeField] private int saveId;
        [SerializeField] private int nameId;
        
        [Space, Header("Properties")]
        [SerializeField] private bool startingBusiness; // if true - already purchased at the start of the game
        [SerializeField] private float incomeGenerationTime;
        [SerializeField] private int baseLevelUpCost;
        [SerializeField] private int baseIncome;
        
        [Space, Header("Upgrades")]
        [SerializeField] private List<BusinessUpgradeConfig> availableUpgrades; // List of all available upgrades
        
        public int SaveId => saveId;
        public bool StartingBusiness => startingBusiness; 
        public int NameId => nameId;
        public float IncomeGenerationTime => incomeGenerationTime;
        public int BaseLevelUpCost => baseLevelUpCost;
        public int BaseIncome => baseIncome;
        public List<BusinessUpgradeConfig> AvailableUpgrades => availableUpgrades; 
    }
} 