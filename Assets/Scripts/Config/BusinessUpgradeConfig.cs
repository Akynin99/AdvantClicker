using System;
using UnityEngine;

namespace AdvantClicker.Config
{
    // Class for configuring business upgrades
    [Serializable]
    public class BusinessUpgradeConfig
    {
        public int NameId;
        public int Cost;
        public float IncomeMultiplier;
    }
} 