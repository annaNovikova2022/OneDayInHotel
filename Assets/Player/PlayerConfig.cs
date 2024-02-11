using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig: ScriptableObject
    {
        public SpriteRenderer SpriteRenderer;
        public Vector3 SpawnPoint;
        public Vector3 PlayingPoint;
    }
}