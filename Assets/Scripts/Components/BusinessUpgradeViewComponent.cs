using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdvantClicker.Components
{
    // Component for connecting an upgrade with its UI representation
    [Serializable]
    public struct BusinessUpgradeViewComponent
    {
        public GameObject ViewObject;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI CostText;
        public Button PurchaseButton;
        public GameObject PurchasedIndicator;
    }
} 