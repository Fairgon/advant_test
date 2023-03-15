using Components;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityEngine;
using UI;
using Data;

namespace UnityComponents.Factories
{
	public class PrefabFactory : MonoBehaviour
	{
		private EcsWorld _world;
		private NamesData _namesData;
		private string _currency;

		public void SetWorld(EcsWorld world, NamesData namesData, string currency)
		{
			_world = world;
			_namesData = namesData;
			_currency = currency;
 		}
		
		public void Spawn(SpawnBusiness spawnData)
		{
			GameObject gameObject = Instantiate(spawnData.Prefab, spawnData.Parent);

			var panel = gameObject.GetComponent<BusinessPanel>();

			panel.Init(spawnData.Data, _namesData, _currency, _world);

			var monoEntity = gameObject.GetComponent<MonoEntity>();

			if (monoEntity == null) 
				return;

			EcsEntity ecsEntity = _world.NewEntity();
			monoEntity.Make(ref ecsEntity);
		}
	}
}