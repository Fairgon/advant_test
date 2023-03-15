using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class NameData
    {
        [SerializeField]
        private string _id = "";
        public string Id => _id;

        [SerializeField]
        private string _name = "";
        public string Name => _name;
    }
}