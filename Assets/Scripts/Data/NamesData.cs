using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Names List")]
    public class NamesData : ScriptableObject
    {
        [SerializeField]
        private List<NameData> _list = null;
        public List<NameData> List => _list;

        public string GetNameById(string id)
        {
            return List.Find(x => x.Id == id).Name;
        }
    }
}