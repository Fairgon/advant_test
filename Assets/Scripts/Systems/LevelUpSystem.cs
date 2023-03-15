using Leopotam.Ecs;
using UnityComponents;
using Data;
using Components;

namespace Systems
{
    public class LevelUpSystem : IEcsRunSystem
    {
		private EcsWorld _world;
		private StaticData _staticData;
		private CurrencyData _currencyData;
		private NamesData _namesData;

		private EcsFilter<LevelUpBusiness> _filter = null;

		public void Run()
		{
			if (_filter.IsEmpty())
			{
				return;
			}

			foreach (int index in _filter)
			{
				ref EcsEntity spawnEntity = ref _filter.GetEntity(index);
				var panel = spawnEntity.Get<LevelUpBusiness>().Panel;

				BusinessData data = _staticData.businesses.Find(x => x.Id == panel.Id);

				if (_currencyData.Value >= data.UpgradePrice)
                {
					_currencyData.Value -= data.UpgradePrice;

					data.Level += 1;
					data.Save();

					panel.Redraw(data, _namesData, _currencyData.Symbol);

					_world.NewEntity().Get<RedrawBalance>() = new RedrawBalance()
					{
						Value = _currencyData.Value,
						Symbol = _currencyData.Symbol
					};
				}

				spawnEntity.Del<LevelUpBusiness>();
			}
		}
	}
}