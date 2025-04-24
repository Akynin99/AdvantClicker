using UnityEngine;
using TMPro;

namespace AdvantClicker.UI
{
    // Root object for placing UI elements
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _walletText;
        [SerializeField] private Transform _businessesContainer;
        [SerializeField] private Transform _upgradesContainer;
        
        // Method to get wallet text component
        public TextMeshProUGUI GetWalletText()
        {
            return _walletText;
        }
        
        // Method to get businesses container
        public Transform GetBusinessesContainer()
        {
            return _businessesContainer;
        }
        
        // Method to get upgrades container
        public Transform GetUpgradesContainer()
        {
            return _upgradesContainer;
        }
    }
} 