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
        [SerializeField] private Image _progressBar;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _incomeText;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private TMP_Text _upgradeCostText;
        [SerializeField] private string _upgradeCostTextPrefix;
        [SerializeField] private string _upgradeCostTextPostfix;
        [SerializeField] private Transform _upgradesContainer;
        [SerializeField] private BusinessUpgradeButton _upgradeButtonPrefab;

        private int _lastLvl = -1;
        private int _lastIncome = -1;
        private int _lastPrice = -1;
        private EcsWorld _ecsWorld;
        private EcsEntity _ecsEntity;
        private BusinessUpgradeButton[] _upgradeButtons;

        public void Init(EcsEntity ecsEntity, string businessName, BusinessUpgrade[] upgrades)
        {
            _ecsEntity = ecsEntity;
            _nameText.text = businessName;
            _levelUpButton.onClick.AddListener(LevelUpButtonPressed);
            CreateUpgradeButtons(upgrades);
        }
        
        public void UpdateProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }

        public void UpdateLevel(int lvl)
        {
            if (_lastLvl == lvl) return;
            _lastLvl = lvl;
            _levelText.text = lvl.ToString();
        }
        
        public void UpdateIncome(int income)
        {
            if (_lastIncome == income) return;
            _lastIncome = income;
            _incomeText.text = income.ToString();
        }
        
        public void UpdateLvlUpPrice(int price)
        {
            if (_lastPrice == price) return;
            _lastPrice = price;
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(_upgradeCostTextPrefix);
            stringBuilder.Append(price);
            stringBuilder.Append(_upgradeCostTextPostfix);
            
            _upgradeCostText.text = stringBuilder.ToString();
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
                var button = Instantiate(_upgradeButtonPrefab, _upgradesContainer);
                button.Init(_ecsEntity, upgrade);
                _upgradeButtons[i] = button;
            }
        }
    }
} 