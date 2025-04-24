using AdvantClicker.Components;
using AdvantClicker.Core;
using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.MonoBehaviours
{
    public class MainUIScreen : EcsUIScreen
    {
        [SerializeField] private Transform businessesContainer;
        [SerializeField] private BusinessPanel businessPrefab;
        
        public override void Init(EcsWorld world)
        {
            base.Init(world);
            CreateBusinessPanels(_ecsWorld);
        }

        private void AddBusinessPanel(EcsEntity businessEntity)
        {
            ref var business = ref businessEntity.Get<Business>();
            BusinessPanel panel = Instantiate(businessPrefab, businessesContainer);
            panel.Init(businessEntity, business.Name, business.Upgrades);
            ref BusinessView component = ref businessEntity.Get<BusinessView>();
            component.BusinessPanel = panel;
        }

        private void CreateBusinessPanels(EcsWorld world)
        {
            var filter = world.GetFilter(typeof(EcsFilter<Business>.Exclude<BusinessView>));
            
            foreach (var i in filter)
            {
                ref var businessEntity = ref filter.GetEntity(i);
                AddBusinessPanel(businessEntity);
            }
        }
    }
}