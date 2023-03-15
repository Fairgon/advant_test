using Leopotam.Ecs;
using UnityComponents;
using Components;
using Data;
using UI;

namespace Systems
{
    public class IncomeSystem : IEcsRunSystem
    {
		private EcsWorld _world;
		private StaticData _staticData;
		private SceneData _sceneData;
		private CurrencyData _currencyData;

		private EcsFilter<BusinessPanelLink> _filter = null;

		public void Run()
		{
			if (_filter.IsEmpty())
			{
				return;
			}

			foreach (BusinessData data in _staticData.businesses)
			{
				if (data.Level == 0)
					continue;

				data.Progress += _sceneData.DeltaTime;

				GetPanel(data.Id).RedrawProgress(data.Progress / data.Delay);

				if (data.Progress >= data.Delay)
                {
					data.Progress = 0f;

					AddMoney(_currencyData, data.CurrentIncome);
				}
			}
		}

		private void AddMoney(CurrencyData data, float value)
        {
			data.Value += (int)value;

			_world.NewEntity().Get<RedrawBalance>() = new RedrawBalance()
			{
				Value = _currencyData.Value,
				Symbol = _currencyData.Symbol
			};
		}

		private BusinessPanel GetPanel(string id)
        {
			foreach (int index in _filter)
			{
				ref EcsEntity entity = ref _filter.GetEntity(index);
				var panel = entity.Get<BusinessPanelLink>();

				if (panel.Value.Id == id)
					return panel.Value;
			}

			return null;
		}
	}
}