using Data;
using Leopotam.Ecs;
using UnityComponents;
using Components;

namespace Systems
{
	public class SpawnBusinesses : IEcsInitSystem
	{
		private EcsWorld _world = null;
		private StaticData _staticData;
		private SceneData _sceneData;
		
		public void Init()
		{
			foreach(BusinessData data in _staticData.businesses)
            {
				data.Load();

				_world.NewEntity().Get<SpawnBusiness>() = new SpawnBusiness
				{
					Prefab = _staticData.BusinessPrefab,
					Parent = _sceneData.Panel,
					Data = data
				};
			}
		}
	}
}