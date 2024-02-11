using System;
using System.Collections.Generic;
using UnityEngine;

namespace WallsItem
{
    [CreateAssetMenu(fileName = "WallsItemConfig", menuName = "Configs/WallsItemConfig")]
    public class WallsItemConfig : ScriptableObject
    {
        [SerializeField] private WallsItemModel[] doorModels;

        public WallsItemModel GetTypeWithId(int id)
        {
            return doorModels[id];
        }
    }

    [Serializable]
    public struct WallsItemModel
    {
        public Sprite Sprite;
        public bool IsOpen;
    }
}