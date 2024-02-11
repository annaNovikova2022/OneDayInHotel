using System;
using System.Collections.Generic;
using DG.Tweening;
using WallsItem;
using Random = UnityEngine.Random;

public class HallController
{
    public bool GameStarted;
    public List<HallView> _hallsList = new List<HallView>();

    private readonly HallView.Pool _hallViewPool;
    private readonly HallConfig _hallConfig;

    private readonly WallsItemView.Pool _doorPool;
    private readonly WallsItemController _wallsItemController;

    private int ResetDoor;
    private bool FirstSpawned=true;
    private float speedAnimation;
    

    public HallController(
        WallsItemController wallsItemController,
        WallsItemView.Pool doorPool,
        HallView.Pool hallViewPool,
        HallConfig hallConfig
    )
    {
        _wallsItemController = wallsItemController;
        _doorPool = doorPool;
        _hallViewPool = hallViewPool;
        _hallConfig = hallConfig;
        
        speedAnimation = _hallConfig.sumPath / _hallConfig.allDuraction;
        FirstSpawn();
    }

    public void FirstSpawn()
    {
        if (FirstSpawned)
        {
            for (int i = 0; i < 5; i++)
            {
                var position = _hallConfig.GetSpawnPoint(i);
                var hall = _hallViewPool.Spawn(position);
                AddAnimatin(() => Despawn(hall),hall);
                AddToList(hall);
            }
            FirstSpawned = false;
        }
    }

    public void Spawn()
    {
        var position = _hallConfig.GetSpawnPoint(4);
        var hall = _hallViewPool.Spawn(position);
        AddAnimatin(() => Despawn(hall),hall);
        if (hall.transform.childCount>0)
        {
            _doorPool.Despawn(hall.transform.GetComponentInChildren<WallsItemView>());
        }
        if (GameStarted)
        {
            SpawnWallsItems(hall);    
        }
        AddToList(hall);
    }

    private void SpawnWallsItems(HallView hall)
    {
        var random = Random.Range(0, 1f);
        if (random > 0.5f)
        {
            SpawnDoor(hall);
            if (ResetDoor > 0)
            {
                ResetDoor--;
            }
        }
        else
        {
            ResetDoor++;
            if (ResetDoor >= 3)
            {
                SpawnDoor(hall);

                ResetDoor = 0;
            }
        }
    }

    private WallsItemView SpawnDoor(HallView hall)
    {
        var random = Random.Range(0, 3);
        WallsItemView wallsItem;
        if (random ==0)
        {
            wallsItem = _wallsItemController.Spawn(random, hall);
            wallsItem.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        else
        {
            wallsItem = _wallsItemController.Spawn(random, hall);
            wallsItem.transform.SetParent(hall.transform, worldPositionStays: false);
        }
        var transformLocalPosition = wallsItem.transform.localPosition;
        transformLocalPosition.y = 1.72f;
        wallsItem.transform.localPosition = transformLocalPosition;

        return wallsItem;
    }
    
    public void Despawn(HallView hallView)
    {
        _hallsList.Remove(hallView);
        _hallViewPool.Despawn(hallView);
        Spawn();
    }
    
    public void DespawnAll()
    {
        foreach (var hallView in _hallsList)
        {
            Despawn(hallView);
        }

        _hallsList.Clear();
    }

    public void AddToList(HallView hall)
    {
        if (!_hallsList.Contains(hall))
        {
            _hallsList.Add(hall);
        }
    }
    
    public void AddAnimatin(TweenCallback despawn, HallView hallView)
    {
        hallView._hallAnimation.Kill();
        
        var duraction = (Math.Abs(_hallConfig.endPositionX) + hallView.transform.position.x)/(speedAnimation);
        
        hallView._hallAnimation = hallView.transform
            .DOMoveX(_hallConfig.endPositionX,duraction)
            .SetEase(Ease.Linear)
            .OnComplete(despawn);
    }
}