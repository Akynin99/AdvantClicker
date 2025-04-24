using AdvantClicker.Components;
using AdvantClicker.Configs;
using AdvantClicker.Utils;
using Leopotam.Ecs;

namespace AdvantClicker.Systems
{
    public class WalletSaveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Wallet> _wallet = null;
        private readonly GameConfig _gameConfig = null;
        
        public void Run()
        {
            foreach (var i in _wallet)
            {
                int balance = _wallet.Get1(i).Balance;
                SaveHelper.SaveWalletBalance(balance);
            }
        }
    }
}