using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    private void Awake()
    {
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }

    private void OnDestroy()
    {
        menuButton.onClick.RemoveAllListeners();
    }

    private void OnMenuButtonClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
