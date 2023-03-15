using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Currency")]
    public class CurrencyData : ScriptableObject
    {
        private int? _value = null;
        public int Value
        {
            get
            {
                if (_value == null)
                    Load();

                return _value.Value;
            }
            set
            {
                _value = value;

                Save();
            }
        }

        public string Symbol = "$";

        public void Save()
        {
            PlayerPrefs.SetInt("Currency" + Symbol, _value.Value);
        }

        public void Load()
        {
            _value = PlayerPrefs.GetInt("Currency" + Symbol, 0);
        }
    }
}