using Code.Scripts.Global;
using Zenject;

namespace Code.Scripts.Installer
{
    public class GameplaySettingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplaySettings>()
                .AsSingle()
                .NonLazy();
        }
    }
}