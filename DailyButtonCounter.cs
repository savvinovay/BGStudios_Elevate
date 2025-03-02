using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyButtonCounter : MonoBehaviour
{
    [SerializeField] private Text counterText;
    [SerializeField] private Button dailyButton;
    [SerializeField] private Text timerText;

    private const string LAST_CLICK_TIME_KEY = "LastClickTime";
    private const string COUNTER_VALUE_KEY = "CounterValue";

    private int currentCount;
    private DateTime lastClickTime;

    private void Start()
    {
        LoadData();
        
        CheckAndResetCounter();
        
        UpdateCounterText();
        
        dailyButton.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        UpdateTimer();
        CheckAndResetCounter();
    }

    private void UpdateTimer()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan timeSinceLastClick = currentTime - lastClickTime;
        
        if (timeSinceLastClick.TotalHours < 24)
        {
            TimeSpan timeUntilNextClick = TimeSpan.FromHours(24) - timeSinceLastClick;
            timerText.text = $"Till next: {timeUntilNextClick.Hours:D2}:{timeUntilNextClick.Minutes:D2}:{timeUntilNextClick.Seconds:D2}";
        }
        else if (timeSinceLastClick.TotalHours < 48)
        {
            TimeSpan timeUntilReset = TimeSpan.FromHours(48) - timeSinceLastClick;
            timerText.text = $"End in: {timeUntilReset.Hours:D2}:{timeUntilReset.Minutes:D2}:{timeUntilReset.Seconds:D2}";
        }
        else
        {
            timerText.text = "Timer end";
        }
    }

    private void OnButtonClick()
    {
        DateTime currentTime = DateTime.Now;
        
        if ((currentTime - lastClickTime).TotalHours >= 48)
        {
            currentCount++;
            lastClickTime = currentTime;
            
            PlayerPrefs.SetString(LAST_CLICK_TIME_KEY, currentTime.ToString());
            PlayerPrefs.SetInt(COUNTER_VALUE_KEY, currentCount);
            PlayerPrefs.Save();
            
        }
    }

    private void LoadData()
    {
        string savedTimeStr = PlayerPrefs.GetString(LAST_CLICK_TIME_KEY, DateTime.MinValue.ToString());
        lastClickTime = DateTime.Parse(savedTimeStr);
        currentCount = PlayerPrefs.GetInt(COUNTER_VALUE_KEY, 0);
    }

    private void CheckAndResetCounter()
    {
        if ((DateTime.Now - lastClickTime).TotalHours >= 48)
        {
            currentCount = 0;
            PlayerPrefs.SetInt(COUNTER_VALUE_KEY, 0);
            PlayerPrefs.Save();
        }
    }

    private void UpdateCounterText()
    {
        counterText.text = currentCount.ToString();
    }
} 