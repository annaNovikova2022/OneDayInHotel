using Player;
using UnityEngine;
using UnityEngine.UI;

public class GameController
{
    private readonly HallController _hallController;
    private readonly PlayerView.Pool _playerPool;
    private readonly PlayerController _playerController;

    public GameController(
        PlayerController playerController,
        HallController hallController)
    {
        _playerController = playerController;
        _hallController = hallController;
        playerController.IsDead += StopGame;
    }

    public void StartGame()
    {
        Spawn();
    }
    public void StopGame()
    {
        Despawn();
    }
        
    private void Spawn( )
    {
        Time.timeScale = 5;
        _playerController.Spawn();
        _hallController.GameStarted = true;
    }

    private void Despawn()
    {
        _playerController.Despawn();
        _hallController.GameStarted = false;
    }
}