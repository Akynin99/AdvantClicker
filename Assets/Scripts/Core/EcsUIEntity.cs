using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker.Core
{
    public class EcsUIEntity : MonoBehaviour
    {
        protected EcsWorld _ecsWorld;
        
        public virtual void Init(EcsWorld world)
        {
            _ecsWorld = world;
        }
    }
}