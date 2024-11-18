using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI hightScoreText;
    private void Awake()
    {
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }

    private void Start()
    {
        float currentGameTime = PlayerPrefs.GetFloat("CurrentGameTime");
        float bestGameTime = PlayerPrefs.GetFloat("BestGameTime");
        TimeSpan time = TimeSpan.FromSeconds(Math.Floor(currentGameTime));
        timeText.text = time.ToString();
        if (currentGameTime <= bestGameTime)
        {
            hightScoreText.enabled = true;
        }
        else
        {
            hightScoreText.enabled = false;
        }
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
