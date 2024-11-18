using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuideMenu : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        backButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        UIManager.Instance.SetGuidePanelActive(false);
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
