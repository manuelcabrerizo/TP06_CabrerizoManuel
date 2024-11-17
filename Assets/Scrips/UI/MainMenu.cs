using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button guideButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        guideButton.onClick.AddListener(OnGuideButtonClick);
        creditsButton.onClick.AddListener(OnCreditsButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        guideButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnSettingsButtonClick()
    {
        UIManager.Instance.SetMainMenuPanelActive(false);
        UIManager.Instance.SetSettingsPanelActive(true);
    }

    private void OnGuideButtonClick()
    {
        UIManager.Instance.SetMainMenuPanelActive(false);
        UIManager.Instance.SetGuidePanelActive(true);
    }

    private void OnCreditsButtonClick()
    {
        UIManager.Instance.SetMainMenuPanelActive(false);
        UIManager.Instance.SetCreditsPanelActive(true);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }



}
