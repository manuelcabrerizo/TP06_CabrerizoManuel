using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDestroy()
    {
        resumeButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }
    private void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.SetPausePanelActive(false);
        UIManager.Instance.SetStatsPanelActive(true);
    }

    private void OnSettingsButtonClick()
    {
        UIManager.Instance.SetPausePanelActive(false);
        UIManager.Instance.SetSettingsPanelActive(true);
    }

    private void OnMenuButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

}
