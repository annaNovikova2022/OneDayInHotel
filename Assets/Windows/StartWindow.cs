using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartWindow : MonoBehaviour
{
    public UIButton StartButton;
    public Canvas CanvasWindow;
    public Transform StartWindowTransform;
    [Inject] private GameController _gameController;
    [Inject] private Camera _mainCamera;
    [Inject] private PlayerController _playerController;

    public StartWindow(PlayerController playerController)
    {
        _playerController = playerController;
    }
    
    private void StartGame()
    {        
        StartWindowTransform.DOLocalMoveY(1550f, 1f).OnComplete(() =>
        {
            CanvasWindow.gameObject.SetActive(false);
        });
        _gameController.StartGame();

    }

    public void EndGame()
    {
        CanvasWindow.gameObject.SetActive(true);
        StartWindowTransform.DOLocalMoveY(1f, 0.5f).OnComplete(()=>{Time.timeScale = 1;});
    }

    private void Start()
    {
        CanvasWindow.worldCamera = _mainCamera;
        StartButton.OnClickButton += StartGame;
        _playerController.IsDead += EndGame;
    }
}

