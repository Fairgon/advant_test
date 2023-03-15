using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class UpgradeData
    {
        public string Id = "";
        public int Price = 0;
        public int IncomeFactor = 0;

        [HideInInspector]
        public bool Purchased = false;

        public float Factor => Purchased ? IncomeFactor / 100f : 0f;
    }
}