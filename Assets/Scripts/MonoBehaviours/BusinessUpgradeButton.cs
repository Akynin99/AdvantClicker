using System.Text;
using AdvantClicker.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdvantClicker.MonoBehaviours
{
    // Prefab for displaying business upgrade in UI
    public class BusinessUpgradeButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _incomeText;
        [SerializeField] private string _incomeTextPrefix;
        [SerializeField] private string _incomeTextPostfix;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private string _costTextPrefix;
        [SerializeField] private string _costTextPostfix;
        [SerializeField] private Button _purchaseButton;
        [SerializeField] private GameObject _purchasedIndicator;
        
        private int _upgradeId;
        private int _businessId;
        private EcsEntity _ecsEntity;
        
        public void Init(EcsEntity entity, BusinessUpgrade upgrade)
        {
            _ecsEntity = entity;
            _upgradeId = upgrade.Id;
            
            if (_purchaseButton != null)
            {
                _purchaseButton.onClick.AddListener(PurchaseButtonPressed);
            }

            _nameText.text = upgrade.Name;

            int multPercent = (int)(upgrade.IncomeMultiplier * 100);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(_incomeTextPrefix);
            stringBuilder.Append(multPercent);
            stringBuilder.Append(_incomeTextPostfix);

            _incomeText.text = stringBuilder.ToString();
            
            stringBuilder.Clear();
            stringBuilder.Append(_costTextPrefix);
            stringBuilder.Append(upgrade.Cost);
            stringBuilder.Append(_costTextPostfix);
            
            _costText.text = stringBuilder.ToString();
            
            _purchasedIndicator.SetActive(false);
            _costText.gameObject.SetActive(true);
        }

        public void SetIsPurchased(bool isPurchased)
        {
            _purchaseButton.interactable = !isPurchased;
            _purchasedIndicator.SetActive(isPurchased);
            _costText.gameObject.SetActive(!isPurchased);
        }
        
        private void PurchaseButtonPressed()
        {
            _ecsEntity.Get<TryToUpgradeSignal>().UpgradeId = _upgradeId;
        }
    }
} 