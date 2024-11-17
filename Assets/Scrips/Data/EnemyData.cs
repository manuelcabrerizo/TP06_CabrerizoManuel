using UnityEngine;

[CreateAssetMenu(fileName = "EmenyData", menuName = "Enemy/Data", order = 1)]

public class EnemyData : ScriptableObject
{
    [Header("Stats")]
    public int MaxLife = 3;

    [Header("Attack")]
    public float TimeToShoot = 3.0f;
    public float ShootSpeed = 4.0f;
    public float ShootRadio = 8.0f;
}