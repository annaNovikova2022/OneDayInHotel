using Zenject;

namespace Score
{
    public class ScoreInstaller: Installer<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<ScoreView>()
                .FromComponentInNewPrefabResource("Score")
                .AsSingle()
                .NonLazy();
        }
    }
}