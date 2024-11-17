using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data", order = 1)]

public class PlayerData : ScriptableObject
{
    [Header("Stats")]
    public int MaxLife = 10;
    public int BaseAttackPower = 1;
    public int IncreaseAttackPower = 4;

    [Header("Movement")]
    public float Speed = 50;
    public float JumpImpulse = 50.0f;

    [Header("Attack")]
    public float AttackDuration = 0.75f;

    [Header("Input")]
    public KeyCode MoveLeftKey = KeyCode.A;
    public KeyCode MoveRightKey = KeyCode.D;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode AttackLeftKey = KeyCode.LeftArrow;
    public KeyCode AttackRightKey = KeyCode.RightArrow;
    public KeyCode AttackDownKey = KeyCode.DownArrow;
}
