using System.Collections.Generic;
using UnityEngine;

namespace AdvantClicker.Config
{
    // ScriptableObject for configuring general game parameters
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int startingBalance;
        [SerializeField] private bool savingEveryFrame;
        [SerializeField] private float savingCooldown;
        [SerializeField] private List<BusinessConfig> businesses;

        public int StartingBalance => startingBalance;
        public List<BusinessConfig> Businesses => businesses;
        public bool SavingEveryFrame => savingEveryFrame;
        public float SavingCooldown => savingCooldown;
    }

} 