using UnityEngine;
using System.Collections.Generic;
using Data;

namespace UnityComponents
{
	[CreateAssetMenu(menuName = "Data/StaticData", fileName = "StaticData")]
	public class StaticData : ScriptableObject
	{
		public GameObject BusinessPrefab = null;
		public List<BusinessData> businesses = null;
	}
}