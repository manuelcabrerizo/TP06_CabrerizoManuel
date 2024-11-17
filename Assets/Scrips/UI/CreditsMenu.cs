using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;

    void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        backButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        UIManager.Instance.SetCreditsPanelActive(false);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            UIManager.Instance.SetMainMenuPanelActive(true);
        }
        else
        {
            UIManager.Instance.SetPausePanelActive(true);
        }
    }
}
