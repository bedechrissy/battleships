using Ninject.Modules;
using Ninject;
using BattleShips.Services;
using BattleShips;

public class Bindings : NinjectModule
{
    public override void Load()
    {
        Bind<IGameService>().To<GameService>();
    }
}