using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI gearCountText;
    [SerializeField] private TextMeshProUGUI timeText;

    private float _time;
    public float GameTime => _time;
    public bool Pause { get; set; }
    public float LastTimeScale { get; set; }

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


        _time = 0;
        Pause = false;
        LastTimeScale = Time.timeScale;
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
            if (!Pause)
            {
                Pause = true;
                LastTimeScale = Time.timeScale;
                Time.timeScale = 0.0f;
                UIManager.Instance.SetPausePanelActive(true);
            }
            else
            {
                Pause = false;
                Time.timeScale = LastTimeScale;
                UIManager.Instance.SetPausePanelActive(false);
                UIManager.Instance.SetSettingsPanelActive(false);
            }
        }
    }
}
