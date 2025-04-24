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
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI incomeText;
        [SerializeField] private string incomeTextPrefix;
        [SerializeField] private string incomeTextPostfix;
        [SerializeField] private TextMeshProUGUI costText;
        [SerializeField] private string costTextPrefix;
        [SerializeField] private string costTextPostfix;
        [SerializeField] private Button purchaseButton;
        [SerializeField] private GameObject purchasedIndicator;
        
        
        private int _upgradeId;
        private int _businessId;
        private EcsEntity _ecsEntity;
        
        public void Init(EcsEntity entity, BusinessUpgrade upgrade)
        {
            _ecsEntity = entity;
            _upgradeId = upgrade.Id;
            
            if (purchaseButton != null)
            {
                purchaseButton.onClick.AddListener(PurchaseButtonPressed);
            }

            nameText.text = upgrade.Name;

            int multPercent = (int)(upgrade.IncomeMultiplier * 100);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(incomeTextPrefix);
            stringBuilder.Append(multPercent);
            stringBuilder.Append(incomeTextPostfix);

            incomeText.text = stringBuilder.ToString();
            
            stringBuilder.Clear();
            stringBuilder.Append(costTextPrefix);
            stringBuilder.Append(upgrade.Cost);
            stringBuilder.Append(costTextPostfix);
            
            costText.text = stringBuilder.ToString();
            
            purchasedIndicator.SetActive(false);
            costText.gameObject.SetActive(true);
        }

        public void SetIsPurchased(bool isPurchased)
        {
            purchaseButton.interactable = !isPurchased;
            
            purchasedIndicator.SetActive(isPurchased);
            costText.gameObject.SetActive(!isPurchased);
        }
        
        private void PurchaseButtonPressed()
        {
            _ecsEntity.Get<TryToUpgradeSignal>().UpgradeId = _upgradeId;
        }
    }
} 