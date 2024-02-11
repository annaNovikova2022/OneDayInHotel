using System.Collections.Generic;

namespace WallsItem
{
    public class WallsItemController
    {
        private readonly WallsItemView.Pool _doorPool;
        private readonly WallsItemConfig _wallsItemConfig;

        private WallsItemView _wallsItemView;
        private Dictionary<HallView, WallsItemView> _wallsItemViews = new();

        public WallsItemController( 
            WallsItemView.Pool doorPool,
            WallsItemConfig wallsItemConfig)
        {
            _wallsItemConfig = wallsItemConfig;
            _doorPool = doorPool;
        }

        public WallsItemView Spawn(int i, HallView hall)
        {
            var door = _doorPool.Spawn(_wallsItemConfig.GetTypeWithId(i));
            _wallsItemViews.Add(hall, door);
            door.IsOpen = _wallsItemConfig.GetTypeWithId(i).IsOpen;
            _wallsItemView = door;
            return door;
        }

        public void CloseTheDoor(HallView hall)
        {
            if (_wallsItemView.IsOpen)
            {
                _wallsItemViews[hall].SpriteRenderer.sprite = _wallsItemConfig.GetTypeWithId(1).Sprite;
                _wallsItemViews[hall].IsOpen = false;

                // _wallsItemView.SpriteRenderer.sprite = _wallsItemConfig.GetTypeWithId(1).Sprite;
                //_wallsItemView.IsOpen = false;
            }
        }
    }
}