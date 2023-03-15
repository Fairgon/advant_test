using Data;
using Leopotam.Ecs;
using UnityComponents;
using UnityComponents.Factories;

namespace Systems
{
	public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
	{
		private EcsWorld _world;
		private SceneData _sceneData;
		private NamesData _namesData;
		private CurrencyData _currencyData;

		private EcsFilter<Components.SpawnBusiness> _spawnFilter = null;
		
		private PrefabFactory _factory;
		
		public void PreInit()
		{
			_factory = _sceneData.Factory;
			_factory.SetWorld(_world, _namesData, _currencyData.Symbol);
		}

		public void Run()
		{
			if (_spawnFilter.IsEmpty())
			{
				return;
			}

			foreach (int index in _spawnFilter)
			{
				ref EcsEntity spawnEntity = ref _spawnFilter.GetEntity(index);
				var spawnPrefabData = spawnEntity.Get<Components.SpawnBusiness>();
				_factory.Spawn(spawnPrefabData);

				spawnEntity.Del<Components.SpawnBusiness>();
			}
		}
	}
}