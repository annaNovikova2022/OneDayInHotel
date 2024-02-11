using UnityEngine;

[CreateAssetMenu(fileName = "HallConfig", menuName = "Configs/HallConfig")]
public class HallConfig : ScriptableObject
{
    public float allDuraction;
    public float endPositionX;
    public float sumPath;
    [SerializeField] private Vector3[] SpawnPoint;

    public Vector3 GetSpawnPoint(int point)
    {
        return SpawnPoint[point];
    }
}