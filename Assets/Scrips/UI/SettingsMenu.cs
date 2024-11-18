using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider uiSoundVolumeSlider;
    [SerializeField] private AudioMixer audioMixer;


    private void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderValueChange);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChange);
        sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeSliderValueChange);
        uiSoundVolumeSlider.onValueChanged.AddListener(OnUiVolumeSliderValueChange);
    }

    private void Start()
    {
        float volume = 0;
        // Set Master Volume Slider
        audioMixer.GetFloat("MasterVolume", out volume);
        masterVolumeSlider.value = Utils.DecibelToLinear(volume);
        // Set Music Volume Slider
        audioMixer.GetFloat("MusicVolume", out volume);
        musicVolumeSlider.value = Utils.DecibelToLinear(volume);
        // Set Sfx Volume Slider
        audioMixer.GetFloat("SfxVolume", out volume);
        sfxVolumeSlider.value = Utils.DecibelToLinear(volume);
        // Set UI Volume Slider
        audioMixer.GetFloat("UiVolume", out volume);
        uiSoundVolumeSlider.value = Utils.DecibelToLinear(volume);
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
