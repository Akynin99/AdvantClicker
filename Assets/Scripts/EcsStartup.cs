using AdvantClicker.Config;
using AdvantClicker.Core;
using AdvantClicker.MonoBehaviours;
using AdvantClicker.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace AdvantClicker
{
    // Entry point for initializing ECS systems
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private NamesConfig _namesConfig;
        [SerializeField] private MainUIScreen _mainUIScreen;
        [SerializeField] private EcsUIScreen[] _ecsUIScreens;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            // Create world and systems
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            // Register systems
            _systems
                // Initialize and setup
                .Add(new WalletInitSystem())
                .Add(new BusinessInitSystem())

                // Game logic
                .Add(new BusinessProgressSystem())
                .Add(new BusinessIncomeSystem())
                .Add(new BusinessLevelUpSystem())
                .Add(new BusinessUpgradeSystem())
                
                // Save logic
                .Add(new BusinessSaveSystem())
                .Add(new WalletSaveSystem())
                
                // UI systems
                .Add(new BusinessPanelUpdateSystem())
                .Add(new WalletViewUpdateSystem())

                // Inject dependencies
                .Inject(_gameConfig)
                .Inject(_namesConfig)
                .Inject(_mainUIScreen)

                // Initialize systems
                .Init();

            // Init UI entities
            for (int i = 0; i < _ecsUIScreens.Length; i++)
            {
                _ecsUIScreens[i].Init(_world);
            }
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            // Cleanup
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
} 