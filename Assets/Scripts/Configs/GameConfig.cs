using System.Collections.Generic;
using UnityEngine;

namespace AdvantClicker.Configs
{
    // ScriptableObject for configuring general game parameters
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int _startingBalance;
        [SerializeField] private bool _savingEveryFrame;
        [SerializeField] private float _savingCooldown;
        [SerializeField] private List<BusinessConfig> _businesses;

        public int StartingBalance => _startingBalance;
        public List<BusinessConfig> Businesses => _businesses;
        public bool SavingEveryFrame => _savingEveryFrame;
        public float SavingCooldown => _savingCooldown;
    }

} 