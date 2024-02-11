using Player;
using UnityEngine;
using Zenject;

namespace WallsItem
{
    public class WallsItemView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [Inject] private PlayerController _playerController;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private WallsItemModel _wallsItemModel;
        
        public bool IsOpen;

        public void Reinit(WallsItemModel wallsItemModel)
        {
            _wallsItemModel = wallsItemModel;
            spriteRenderer.sprite = _wallsItemModel.Sprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsOpen)
            {
                var player = _playerController.PlayerView;
                player.BelowTheDoor = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var player = _playerController.PlayerView;
            player.BelowTheDoor = false;
        }

        public class Pool : MonoMemoryPool<WallsItemModel, WallsItemView>
        {
            protected override void Reinitialize(WallsItemModel wallsItemModel, WallsItemView item)
            {
                item.Reinit(wallsItemModel);
            }
        }
    }
}