using Leopotam.Ecs;
using UnityComponents;
using Data;
using Components;

namespace Systems
{
    public class UpgradeSystem : IEcsRunSystem
    {
		private EcsWorld _world;
		private StaticData _staticData;
		private CurrencyData _currencyData;
		private NamesData _namesData;

		private EcsFilter<UpgradeBusiness> _filter = null;

		public void Run()
		{
			if (_filter.IsEmpty())
			{
				return;
			}

			foreach (int index in _filter)
			{
				ref EcsEntity spawnEntity = ref _filter.GetEntity(index);
				var upgrade = spawnEntity.Get<UpgradeBusiness>();

				BusinessData data = _staticData.businesses.Find(x => x.Id == upgrade.Panel.Id);
				UpgradeData upgradeData = data.Upgrade_1.Id == upgrade.Id ? data.Upgrade_1 : data.Upgrade_2;

				if (_currencyData.Value >= upgradeData.Price)
                {
					_currencyData.Value -= upgradeData.Price;

					upgradeData.Purchased = true;
					data.Save();

					upgrade.Panel.Redraw(data, _namesData, _currencyData.Symbol);

					_world.NewEntity().Get<RedrawBalance>() = new RedrawBalance()
					{
						Value = _currencyData.Value,
						Symbol = _currencyData.Symbol
					};
				}

				spawnEntity.Del<UpgradeBusiness>();
			}
		}
	}
}