using System.Text;
using AdvantClicker.Components;
using AdvantClicker.Core;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace AdvantClicker.MonoBehaviours
{
    public class WalletPanel : EcsUIEntity
    {
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private string _moneyTextPrefix;
        [SerializeField] private string _moneyTextPostfix;
        
        private int _lastBalance = -1;

        public override void Init(EcsWorld world)
        {
            base.Init(world);
            world.NewEntity().Get<WalletView>().WalletPanel = this;
        }
        
        public void UpdateBalance(int balance)
        {
            if (balance != _lastBalance)
            {
                _lastBalance = balance;
                
                _moneyText.text = $"{_moneyTextPrefix}{_lastBalance}{_moneyTextPostfix}";
            }
        }
    }
}