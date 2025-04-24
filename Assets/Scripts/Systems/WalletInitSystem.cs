using Leopotam.Ecs;
using AdvantClicker.Components;
using AdvantClicker.Config;
using AdvantClicker.Utils;

namespace AdvantClicker.Systems
{
    // Initializes wallet from configuration or from save
    public class WalletInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly GameConfig _gameConfig = null;

        public void Init()
        {
            var walletEntity = _world.NewEntity();
            ref var wallet = ref walletEntity.Get<PlayerWallet>();

            if (SaveHelper.WalletSaveExists())
            {
                wallet.Balance = SaveHelper.LoadWalletBalance();
            }
            else
            {
                wallet.Balance = _gameConfig.StartingBalance;
            }
        }

        
    }
} 