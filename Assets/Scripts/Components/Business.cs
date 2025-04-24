using System;
using AdvantClicker.Config;
using UnityEngine.Serialization;

namespace AdvantClicker.Components
{
    public struct Business
    {
        public int SaveId;
        public string Name;
        public int Level;
        public bool IsPurchased;
        public float Progress;
        public float IncomeGenerationTime;
        public int BaseIncome;
        public int BaseLevelUpCost;
        public BusinessUpgrade[] Upgrades;
    }
} 