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
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private string moneyTextPrefix;
        [SerializeField] private string moneyTextPostfix;
        
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
                
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(moneyTextPrefix);
                stringBuilder.Append(_lastBalance);
                stringBuilder.Append(moneyTextPostfix);
                
                moneyText.text = stringBuilder.ToString();
            }
        }
    }
}