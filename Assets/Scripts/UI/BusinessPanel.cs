using UnityEngine;
using UnityEngine.UI;
using Data;
using Leopotam.Ecs;
using Components;

namespace UI
{
    public class BusinessPanel : MonoBehaviour
    {
        private readonly string PRICE_LABEL = "Price: ";
        private readonly string LEVEL_LABEL = "Level: ";
        private readonly string INCOME_LABEL = "Income: ";

        public string Id { get; private set; } = "";

        [SerializeField]
        private Text _title = null;
        [SerializeField]
        private Text _level = null;
        [SerializeField]
        private Text _income = null;
        [SerializeField]
        private Image _progressBar = null;
        [SerializeField]
        private Text _price = null;
        [SerializeField]
        private Button _levelUpButton = null;
        [SerializeField]
        private UpgradeButton upgradeButton_1 = null;
        [SerializeField]
        private UpgradeButton upgradeButton_2 = null;
        
        private EcsWorld _world;

        public void Init(BusinessData data, NamesData names, string currency, EcsWorld world)
        {
            _world = world;

            Id = data.Id;

            Redraw(data, names, currency);
            RedrawProgress(data.Progress);

            _levelUpButton.onClick.AddListener(OnLevelUpClick);

            upgradeButton_1.Upgrade.onClick.AddListener(() => OnUpgradeClick(data.Upgrade_1.Id));
            upgradeButton_2.Upgrade.onClick.AddListener(() => OnUpgradeClick(data.Upgrade_2.Id));
        }

        public void OnLevelUpClick()
        {
            _world.NewEntity().Get<LevelUpBusiness>() = new LevelUpBusiness()
            {
                Panel = this
            };
        }

        public void OnUpgradeClick(string upgradeId)
        {
            _world.NewEntity().Get<UpgradeBusiness>() = new UpgradeBusiness()
            {
                Panel = this,
                Id = upgradeId
            };
        }

        public void RedrawProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }

        public void Redraw(BusinessData data, NamesData names, string currency)
        {
            _title.text = names.GetNameById(data.Id);
            _level.text = LEVEL_LABEL + data.Level.ToString();
            _income.text = INCOME_LABEL + data.CurrentIncome + currency;

            _price.text = PRICE_LABEL + data.UpgradePrice;

            if (data.Upgrade_1.Purchased)
                upgradeButton_1.Upgrade.interactable = false;
        
            upgradeButton_1.Redraw(names.GetNameById(data.Upgrade_1.Id),
                                   data.Upgrade_1.Price,
                                   data.Upgrade_1.Purchased,
                                   data.Upgrade_1.IncomeFactor,
                                   currency);

            if (data.Upgrade_2.Purchased)
                upgradeButton_2.Upgrade.interactable = false;

            upgradeButton_2.Redraw(names.GetNameById(data.Upgrade_2.Id),
                                   data.Upgrade_2.Price,
                                   data.Upgrade_2.Purchased,
                                   data.Upgrade_2.IncomeFactor,
                                   currency);
        }
    }
}