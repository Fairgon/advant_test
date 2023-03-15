using Leopotam.Ecs;
using UnityComponents;
using Data;
using Components;

namespace Systems
{
	public class RedrawBalanceSystem : IEcsRunSystem, IEcsPreInitSystem
	{
		private SceneData _sceneData;
		private CurrencyData _currencyData;
		private EcsFilter<RedrawBalance> _filter = null;

		public void PreInit()
		{
			_sceneData.BalanceView.Redraw(_currencyData.Value, _currencyData.Symbol);
		}

		public void Run()
		{
			if (_filter.IsEmpty())
			{
				return;
			}

			foreach (int index in _filter)
			{
				ref EcsEntity entity = ref _filter.GetEntity(index);
				var redrawBalance = entity.Get<RedrawBalance>();

				_sceneData.BalanceView.Redraw(redrawBalance.Value, redrawBalance.Symbol);

				entity.Del<RedrawBalance>();
			}
		}
	}
}