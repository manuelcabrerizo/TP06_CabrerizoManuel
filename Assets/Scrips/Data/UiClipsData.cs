using UnityEngine;


[CreateAssetMenu(fileName = "AudioClipsData", menuName = "AudioClips/Ui", order = 1)]

public class UiClipsData : ScriptableObject
{
    [Header("Sound Effects")]
    public AudioClip HoverClip;
    public AudioClip ClickClip;
}
