using System.Collections.Generic;
using System.Text;
using AdvantClicker.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdvantClicker.MonoBehaviours
{
    // Prefab for displaying business in UI
    public class BusinessPanel : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI incomeText;
        [SerializeField] private Button levelUpButton;
        [SerializeField] private TextMeshProUGUI upgradeCostText;
        [SerializeField] private string upgradeCostTextPrefix;
        [SerializeField] private string upgradeCostTextPostfix;
        [SerializeField] private Transform upgradesContainer;
        [SerializeField] private BusinessUpgradeButton upgradeButtonPrefab;

        private int _lastLvl = -1;
        private int _lastIncome = -1;
        private int _lastPrice = -1;
        private EcsWorld _ecsWorld;
        private EcsEntity _ecsEntity;
        private BusinessUpgradeButton[] _upgradeButtons;

        public void Init(EcsEntity ecsEntity, string businessName, BusinessUpgrade[] upgrades)
        {
            _ecsEntity = ecsEntity;

            nameText.text = businessName;
            
            levelUpButton.onClick.AddListener(LevelUpButtonPressed);
            
            CreateUpgradeButtons(upgrades);
        }
        
        public void UpdateProgress(float progress)
        {
            progressBar.fillAmount = progress;
        }

        public void UpdateLevel(int lvl)
        {
            if (_lastLvl == lvl) return;

            _lastLvl = lvl;
            
            levelText.text = lvl.ToString();
        }
        
        public void UpdateIncome(int income)
        {
            if (_lastIncome == income) return;

            _lastIncome = income;
            
            incomeText.text = income.ToString();
        }
        
        public void UpdateLvlUpPrice(int price)
        {
            if (_lastPrice == price) return;

            _lastPrice = price;
            
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.Append(upgradeCostTextPrefix);
            stringBuilder.Append(price);
            stringBuilder.Append(upgradeCostTextPostfix);
            
            upgradeCostText.text = stringBuilder.ToString();
        }

        public void UpdateUpgradeButtons(BusinessUpgrade[] upgrades)
        {
            for (int i = 0; i < _upgradeButtons.Length; i++)
            {
                _upgradeButtons[i].SetIsPurchased(upgrades[i].IsPurchased);
            }
        }

        private void LevelUpButtonPressed()
        {
            _ecsEntity.Get<TryToLevelUpBusinessSignal>();
        }

        private void CreateUpgradeButtons(BusinessUpgrade[] upgrades)
        {
            _upgradeButtons = new BusinessUpgradeButton[upgrades.Length];
            for (var i = 0; i < upgrades.Length; i++)
            {
                var upgrade = upgrades[i];
                var button = Instantiate(upgradeButtonPrefab, upgradesContainer);
                button.Init(_ecsEntity, upgrade);
                _upgradeButtons[i] = button;
            }
        }
    }
} 