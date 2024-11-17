using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gearCountText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float _time;
    private bool _pause;

    private void Awake()
    {
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(Math.Floor(_time));
        

        timeText.text = time.ToString();
        gearCountText.text = PlayerController.Instance.GearCount.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0.0f;
                UIManager.Instance.SetStatsPanelActive(false);
                UIManager.Instance.SetPausePanelActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                UIManager.Instance.SetPausePanelActive(false);
                UIManager.Instance.SetSettingsPanelActive(false);
                UIManager.Instance.SetStatsPanelActive(true);
            }
        }

        
    }
}
