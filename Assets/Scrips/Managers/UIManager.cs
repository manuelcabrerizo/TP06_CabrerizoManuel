using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private GameObject powerUpsPanel;
    [SerializeField] private GameObject shipPartsPanel;
    [SerializeField] private GameObject shopPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetMainMenuPanelActive(bool value)
    {
        if (mainMenuPanel)
        {
            mainMenuPanel.SetActive(value);        
        }
    }

    public void SetPausePanelActive(bool value)
    {
        if (pausePanel)
        {
            pausePanel.SetActive(value);
        }
    }

    public void SetSettingsPanelActive(bool value)
    {
        if (settingPanel)
        {
            settingPanel.SetActive(value);
        }
    }

    public void SetGuidePanelActive(bool value)
    {
        if (guidePanel)
        {
            guidePanel.SetActive(value);
        }
    }

    public void SetCreditsPanelActive(bool value)
    {
        if (creditsPanel)
        {
            creditsPanel.SetActive(value);
        }
    }

    public void SetGameUIActive(bool value)
    {
        if (statsPanel)
        {
            statsPanel.SetActive(value);
        }
        if (powerUpsPanel)
        {
            powerUpsPanel.SetActive(value);
        }
        if (shipPartsPanel)
        {
            shipPartsPanel.SetActive(value);
        }
    }

    public void SetShopPanelActive(bool value)
    {
        if (shopPanel)
        {
            shopPanel.SetActive(value);
        }
    }



}
