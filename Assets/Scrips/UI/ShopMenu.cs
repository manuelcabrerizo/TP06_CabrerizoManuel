using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private Button shopItem1Button;
    [SerializeField] private Button shopItem2Button;
    [SerializeField] private Button shopItem3Button;
    [SerializeField] private Button shopItem4Button;
    [SerializeField] private Button takeOffButton;

    [SerializeField] private TextMeshProUGUI price1Text;
    [SerializeField] private TextMeshProUGUI price2Text;
    [SerializeField] private TextMeshProUGUI price3Text;
    [SerializeField] private TextMeshProUGUI price4Text;

    private void Awake()
    {
        shopItem1Button.onClick.AddListener(OnItem1Click);
        shopItem2Button.onClick.AddListener(OnItem2Click);
        shopItem3Button.onClick.AddListener(OnItem3Click);
        shopItem4Button.onClick.AddListener(OnItem4Click);

    }
    private void OnDestroy()
    {
        shopItem1Button.onClick.RemoveAllListeners();
        shopItem2Button.onClick.RemoveAllListeners();
        shopItem3Button.onClick.RemoveAllListeners();
        shopItem4Button.onClick.RemoveAllListeners();
    }

    private void OnItem1Click()
    {
        int price = 0;
        if (int.TryParse(price1Text.text, out price))
        {
            if (PlayerController.Instance.GearCount >= price)
            {
                PlayerController.Instance.GearCount -= price;
                shopItem1Button.image.color = Color.green;
                shopItem1Button.onClick.RemoveListener(OnItem1Click);
            }
        }
    }

    private void OnItem2Click()
    {
        int price = 0;
        if (int.TryParse(price2Text.text, out price))
        {
            if (PlayerController.Instance.GearCount >= price)
            {
                PlayerController.Instance.GearCount -= price;
                shopItem2Button.image.color = Color.green;
                shopItem2Button.onClick.RemoveListener(OnItem2Click);
            }
        }
    }

    private void OnItem3Click()
    {
        int price = 0;
        if (int.TryParse(price3Text.text, out price))
        {
            if (PlayerController.Instance.GearCount >= price)
            {
                PlayerController.Instance.GearCount -= price;
                shopItem3Button.image.color = Color.green;
                shopItem3Button.onClick.RemoveListener(OnItem3Click);
            }
        }
    }

    private void OnItem4Click()
    {
        int price = 0;
        if (int.TryParse(price4Text.text, out price))
        {
            if (PlayerController.Instance.GearCount >= price)
            {
                PlayerController.Instance.GearCount -= price;
                shopItem4Button.image.color = Color.green;
                shopItem4Button.onClick.RemoveListener(OnItem4Click);
            }
        }
    }

}
