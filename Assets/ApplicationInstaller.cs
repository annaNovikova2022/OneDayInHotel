using WallsItem;
using Player;
using Score;
using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public Object prefab;
    public override void InstallBindings()
    {
        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource("Main Camera")
            .AsSingle()
            .NonLazy();
        
        HallInstaller.Install(Container);
        
        WallsItemInstaller.Install(Container);
        
        PlayerInstaller.Install(Container);
        
        ScoreInstaller.Install(Container);
        
        Container
            .Bind<GameController>()
            .AsSingle()
            .NonLazy();

        Container.Bind<StartWindow>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}