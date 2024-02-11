using Zenject;

public class HallInstaller : Installer<HallInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<HallConfig>()
            .FromScriptableObjectResource("HallConfig")
            .AsSingle()
            .NonLazy();

        Container
            .BindMemoryPool<HallView, HallView.Pool>()
            .WithInitialSize(6)
            .FromComponentInNewPrefabResource("HallView")
            .UnderTransformGroup("Hall");

        Container
            .Bind<HallController>()
            .AsSingle()
            .NonLazy();
        
    }
}