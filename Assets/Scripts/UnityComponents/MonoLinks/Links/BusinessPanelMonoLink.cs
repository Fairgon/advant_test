using Components;
using UnityEngine;
using UnityComponents.MonoLinks;
using Leopotam.Ecs;
using UI;

namespace UnityComponents.Links
{
    [RequireComponent(typeof(BusinessPanel))]
    public class BusinessPanelMonoLink : MonoLink<BusinessPanelLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<BusinessPanelLink>() = new BusinessPanelLink
            {
                Value = GetComponent<BusinessPanel>()
            };
        }
    }
}