using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider uiSoundVolumeSlider;

    private void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderValueChange);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChange);
        sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeSliderValueChange);
        uiSoundVolumeSlider.onValueChanged.AddListener(OnUiVolumeSliderValueChange);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        backButton.onClick.RemoveAllListeners();
        masterVolumeSlider.onValueChanged.RemoveAllListeners();
        musicVolumeSlider.onValueChanged.RemoveAllListeners();
        sfxVolumeSlider.onValueChanged.RemoveAllListeners();
        uiSoundVolumeSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        UIManager.Instance.SetSettingsPanelActive(false);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            UIManager.Instance.SetMainMenuPanelActive(true);
        }
        else
        {
            UIManager.Instance.SetPausePanelActive(true);
        }
    }

    private void OnMasterVolumeSliderValueChange(float value)
    {
        AudioManager.Instance.SetMasterVolume(value);
    }

    private void OnMusicVolumeSliderValueChange(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    private void OnSfxVolumeSliderValueChange(float value)
    {
        AudioManager.Instance.SetSfxVolume(value);
    }

    private void OnUiVolumeSliderValueChange(float value)
    {
        AudioManager.Instance.SetUiVolume(value);
    }
}
