using Zenject;

namespace WallsItem
{
    public class WallsItemInstaller : Installer<WallsItemInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<WallsItemConfig>()
                .FromScriptableObjectResource("WallsItemConfig")
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<WallsItemController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<WallsItemView, WallsItemView.Pool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefabResource("Item")
                .UnderTransformGroup("Hall");
        }
    }
}