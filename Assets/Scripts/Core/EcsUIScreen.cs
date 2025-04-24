using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.Core
{
    public class EcsUIScreen : MonoBehaviour
    {
        [SerializeField] private EcsUIEntity[] ecsUIEntities;
        
        protected EcsWorld _ecsWorld;
        
        public virtual void Init(EcsWorld world)
        {
            _ecsWorld = world;

            for (int i = 0; i < ecsUIEntities.Length; i++)
            {
                ecsUIEntities[i].Init(world);
            }
        }
    }
}