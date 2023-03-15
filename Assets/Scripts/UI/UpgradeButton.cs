using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        private readonly string PRICE_LABEL = "Price: ";
        private readonly string INCOME_LABEL = "Income: +";
        private readonly string PURCHASED = "Purchased";

        [SerializeField]
        private Text _title = null;
        [SerializeField]
        private Text _price = null;
        [SerializeField]
        private Text _income = null;
        [SerializeField]
        private Button _upgrade = null;
        public Button Upgrade => _upgrade;

        public void Redraw(string name, int price, bool purchased, int income, string currency)
        {
            _title.text = name;

            _price.text = purchased ? PURCHASED : PRICE_LABEL + price + currency;
            
            _income.text = INCOME_LABEL + income + "%";
        }
    }
}