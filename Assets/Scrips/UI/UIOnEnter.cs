using UnityEngine;
using UnityEngine.EventSystems;

public class UIOnEnter : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UiClipsData UiClipsData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayClip(UiClipsData.HoverClip, AudioSourceType.UI);
    }
}
