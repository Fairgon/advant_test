using UnityComponents.Factories;
using UnityEngine;
using UI;

namespace UnityComponents
{
	public class SceneData : MonoBehaviour
	{
		public PrefabFactory Factory;
		public Transform Panel;
		public MoneyView BalanceView;
		public float DeltaTime;
	}
}