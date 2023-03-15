using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Business")]
    public class BusinessData : ScriptableObject
    {
        public string Id = "";
        public int Level = 0;
        public int Price = 0;
        public int Income = 0;
        public float Delay = 0f;

        public float Progress = 0f;

        public UpgradeData Upgrade_1 = null;
        public UpgradeData Upgrade_2 = null;

        public int UpgradePrice => (Level + 1) * Price;
        public float CurrentIncome => (Level * Income) * (1 + Upgrade_1.Factor + Upgrade_2.Factor);

        public void Save()
        {
            var saveStr = Level + ":" + Upgrade_1.Purchased + ":" + Upgrade_2.Purchased + ":" + Progress.ToString();

            PlayerPrefs.SetString(Id, saveStr);
        }

        public void Load()
        {
            var loadStr = PlayerPrefs.GetString(Id);

            if (loadStr == "")
                return;

            var mas = loadStr.Split(":");

            int.TryParse(mas[0], out Level);
            bool.TryParse(mas[1], out Upgrade_1.Purchased);
            bool.TryParse(mas[2], out Upgrade_2.Purchased);
            float.TryParse(mas[3], out Progress);
        }
    }
}