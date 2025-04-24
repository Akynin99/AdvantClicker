using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.Core
{
    public class EcsUIScreen : MonoBehaviour
    {
        [SerializeField] private EcsUIEntity[] _ecsUIEntities;
        
        protected EcsWorld _ecsWorld;
        
        public virtual void Init(EcsWorld world)
        {
            _ecsWorld = world;

            for (int i = 0; i < _ecsUIEntities.Length; i++)
            {
                _ecsUIEntities[i].Init(world);
            }
        }
    }
}