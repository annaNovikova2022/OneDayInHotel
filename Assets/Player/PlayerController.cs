using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using WallsItem;
using Zenject;

namespace Player
{
    public class PlayerController : ITickable
    {
        public Action IsDead;
        public Action OnTakeTowel;
        public PlayerView PlayerView => _playerView;

        private readonly WallsItemController _wallsItemController;
        private readonly PlayerView.Pool _playerPool;
        private readonly PlayerConfig _playerConfig;
        private readonly HallController _hallController;

        private PlayerView _playerView;
        private TickableManager _tickableManager;
        
        public PlayerController(
            HallController hallController,
            WallsItemController wallsItemController,
            PlayerConfig playerConfig,
            PlayerView.Pool playerPool,
            TickableManager tickableManager)
        {
            _hallController = hallController;
            _playerConfig = playerConfig;
            _playerPool = playerPool;
            _wallsItemController = wallsItemController;
            
            _tickableManager = tickableManager;

        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                TakeTowels(); 
            } 
        }

        private void TakeTowels()
        {
            if (_playerView.BelowTheDoor)
            {
                //_wallsItemController.CloseTheDoor(_hallController._hallsList[1]);
                OnTakeTowel?.Invoke();
            }
            else
            {
                IsDead?.Invoke();
            }
        }

        public void Spawn()
        {
            _playerView = _playerPool.Spawn();
            _playerView.transform.position = _playerConfig.SpawnPoint;
            Moving(_playerConfig.PlayingPoint);
            _tickableManager.Add(this);
        }

        public void Despawn()
        {
            _playerPool.Despawn(_playerView); 
            _tickableManager.Remove(this);
        }

        private void Moving(Vector3 point)
        {
            _playerView.transform.DOMove(point, 4);
        }
    }
}