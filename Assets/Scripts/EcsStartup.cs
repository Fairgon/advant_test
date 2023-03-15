using Leopotam.Ecs;
using UnityEngine;
using UnityComponents;
using Systems;
using Data;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        [SerializeField]
        private StaticData _staticData = null;
        [SerializeField]
        private SceneData _sceneData = null;
        [SerializeField]
        private NamesData _namesData = null;
        [SerializeField]
        private CurrencyData _currencyData = null;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            _systems
                .Add(new IncomeSystem())
                .Add(new SpawnBusinesses())
                .Add(new SpawnSystem())
                .Add(new RedrawBalanceSystem())
                .Add(new LevelUpSystem())
                .Add(new UpgradeSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Inject(_namesData)
                .Inject(_currencyData)
                .Init();
        }

        void Update()
        {
            _sceneData.DeltaTime = Time.deltaTime;

            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}