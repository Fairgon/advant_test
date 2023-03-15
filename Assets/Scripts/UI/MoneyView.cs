using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoneyView : MonoBehaviour
    {
        private readonly string BALANCE_LABEL = "BALANCE: ";

        [SerializeField]
        private Text _label = null;

        public void Redraw(int value, string symbol)
        {
            _label.text = BALANCE_LABEL + value + symbol;
        }
    }
}