using DG.Tweening;
using UnityEngine;
using Zenject;

public class HallView : MonoBehaviour
{
    public Tween _hallAnimation;
    private void Reinit(Vector3 SpawnPosition)
    {
        transform.position = SpawnPosition;
    }
    public class Pool : MonoMemoryPool<Vector3, HallView>
    {
        protected override void Reinitialize(Vector3 SpawnPosition, HallView item)
        {
            item.Reinit(SpawnPosition);
        }
        
    }
}