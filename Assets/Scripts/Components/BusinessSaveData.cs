using System;
using UnityEngine;

namespace AdvantClicker.Components
{
    public struct BusinessSaveData
    {
        public int SaveId;
        public int Level;
        public float Progress;
        public bool[] Upgrades;
        public float LastSaveTime;
    }
}