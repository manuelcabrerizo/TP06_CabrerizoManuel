using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipsData", menuName = "AudioClips/Sfx", order = 1)]

public class SfxClipsData : ScriptableObject
{
    [Header("Sound Effects")]
    public AudioClip JumpClip;
    public AudioClip LandClip;
    public AudioClip AttackClip;
    public AudioClip HitClip;
    public AudioClip GrabClip;
    public AudioClip ShootHitClip;
    public AudioClip ShootFireClip;
}
