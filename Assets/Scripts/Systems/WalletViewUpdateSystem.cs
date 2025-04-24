using AdvantClicker.Components;
using Leopotam.Ecs;

namespace AdvantClicker.Systems
{
    public class WalletViewUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Wallet> _wallet = null;
        private readonly EcsFilter<WalletView> _views = null;
        
        public void Run()
        {
            int balance = 0;
            
            foreach (var i in _wallet)
            {
                balance = _wallet.Get1(i).Balance;
                break;
            }
            
            foreach (var i in _views)
            {
                ref var view = ref _views.Get1(i);
                
                view.WalletPanel.UpdateBalance(balance);
            }
        }
    }
}