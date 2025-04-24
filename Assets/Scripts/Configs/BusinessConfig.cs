using System.Collections.Generic;
using UnityEngine;

namespace AdvantClicker.Configs
{
    // ScriptableObject for configuring business parameters
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "Config/Business")]
    public class BusinessConfig : ScriptableObject
    {
        [Header("Identifiers")]
        [SerializeField] private int _saveId;
        [SerializeField] private int _nameId;
        
        [Space, Header("Properties")]
        [SerializeField] private bool _startingBusiness; // if true - already purchased at the start of the game
        [SerializeField] private float _incomeGenerationTime;
        [SerializeField] private int _baseLevelUpCost;
        [SerializeField] private int _baseIncome;
        
        [Space, Header("Upgrades")]
        [SerializeField] private List<BusinessUpgradeConfig> _availableUpgrades; // List of all available upgrades
        
        public int SaveId => _saveId;
        public bool StartingBusiness => _startingBusiness; 
        public int NameId => _nameId;
        public float IncomeGenerationTime => _incomeGenerationTime;
        public int BaseLevelUpCost => _baseLevelUpCost;
        public int BaseIncome => _baseIncome;
        public List<BusinessUpgradeConfig> AvailableUpgrades => _availableUpgrades; 
    }
} 