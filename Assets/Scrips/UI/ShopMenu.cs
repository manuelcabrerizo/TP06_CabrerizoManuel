using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private PricesData PricesData;

    [SerializeField] private Button shopItem1Button;
    [SerializeField] private Button shopItem2Button;
    [SerializeField] private Button shopItem3Button;
    [SerializeField] private Button shopItem4Button;
    [SerializeField] private Button takeOffButton;

    [SerializeField] private TextMeshProUGUI price1Text;
    [SerializeField] private TextMeshProUGUI price2Text;
    [SerializeField] private TextMeshProUGUI price3Text;
    [SerializeField] private TextMeshProUGUI price4Text;
    [SerializeField] private TextMeshProUGUI takeOffText;

    private void Awake()
    {
        price1Text.text = PricesData.ShipPart1.ToString();
        price2Text.text = PricesData.ShipPart2.ToString();
        price3Text.text = PricesData.ShipPart3.ToString();
        price4Text.text = PricesData.ShipPart4.ToString();

        shopItem1Button.onClick.AddListener(OnItem1Click);
        shopItem2Button.onClick.AddListener(OnItem2Click);
        shopItem3Button.onClick.AddListener(OnItem3Click);
        shopItem4Button.onClick.AddListener(OnItem4Click);
        takeOffButton.onClick.AddListener(OnTakeOffButtonClick);

    }
    private void OnDestroy()
    {
        shopItem1Button.onClick.RemoveAllListeners();
        shopItem2Button.onClick.RemoveAllListeners();
        shopItem3Button.onClick.RemoveAllListeners();
        shopItem4Button.onClick.RemoveAllListeners();
        takeOffButton.onClick.RemoveAllListeners();
    }

    private void OnItem1Click()
    {
        int price = 0;
        if (int.TryParse(price1Text.text, out price))
        {
            if (PlayerController.Instance.GearCount >= price)
            {
                PlayerController.Instance.GearCount -= price;
                PlayerController.Instance.ShipPartsBuyed++;
                shopItem1Button.image.color = Color.green;
                shopItem1Button.onClick.RemoveListener(OnItem1Click);
                if (PlayerController.Instance.CanTakeOff())
                {
                    takeOffText.color = Color.green;
                }
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
                PlayerController.Instance.ShipPartsBuyed++;
                shopItem2Button.image.color = Color.green;
                shopItem2Button.onClick.RemoveListener(OnItem2Click);
                if (PlayerController.Instance.CanTakeOff())
                {
                    takeOffText.color = Color.green;
                }
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
                PlayerController.Instance.ShipPartsBuyed++;
                shopItem3Button.image.color = Color.green;
                shopItem3Button.onClick.RemoveListener(OnItem3Click);
                if (PlayerController.Instance.CanTakeOff())
                {
                    takeOffText.color = Color.green;
                }
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
                PlayerController.Instance.ShipPartsBuyed++;
                shopItem4Button.image.color = Color.green;
                shopItem4Button.onClick.RemoveListener(OnItem4Click);
                if (PlayerController.Instance.CanTakeOff())
                {
                    takeOffText.color = Color.green;
                }
            }
        }
    }

    private void OnTakeOffButtonClick()
    {
        if (PlayerController.Instance.CanTakeOff())
        {
            PlayerPrefs.SetFloat("CurrentGameTime", GameManager.Instance.GameTime);

            if (!PlayerPrefs.HasKey("BestGameTime"))
            {
                PlayerPrefs.SetFloat("BestGameTime", GameManager.Instance.GameTime);
            }
            else
            {
                float bestGameTime = PlayerPrefs.GetFloat("BestGameTime");
                if (GameManager.Instance.GameTime < bestGameTime)
                {
                    PlayerPrefs.SetFloat("BestGameTime", GameManager.Instance.GameTime);
                }
            }

            SceneManager.LoadScene("Win");
        }
    }

}
