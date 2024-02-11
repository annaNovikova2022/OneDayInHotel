using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerView : MonoBehaviour
{

    public bool BelowTheDoor;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public class Pool : MonoMemoryPool<PlayerView>
    {
        protected void Reinitialize( PlayerView item)
        {

        }
    }
}