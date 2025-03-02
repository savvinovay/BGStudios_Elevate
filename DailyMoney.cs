using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DailyMoney : MonoBehaviour
{
    public GameObject image;
    public GameObject button;
    public int moneyToAdd = 100; // Количество денег для добавления
    public string buttonID = "Button1"; // Задайте разные ID для разных кнопок в инспекторе
    
    void Start()
    {
        // Проверяем состояние конкретной кнопки по её ID
        if (PlayerPrefs.GetInt("ButtonPressed_" + buttonID, 0) == 1)
        {
            ApplyButtonEffects();
        }
    }

    public void BrightenAndDestroy()
    {
        // Получаем текущее количество денег
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        
        // Проверяем, не станет ли баланс отрицательным
        if (currentMoney + moneyToAdd < 0)
        {
            // Если баланс будет отрицательным, прерываем выполнение метода
            Debug.Log("Недостаточно денег!");
            return;
        }
        
        // Сохраняем состояние конкретной кнопки
        PlayerPrefs.SetInt("ButtonPressed_" + buttonID, 1);
        
        // Добавляем деньги
        currentMoney += moneyToAdd;
        
        // Сохраняем новое значение денег
        PlayerPrefs.SetInt("Money", currentMoney);
        PlayerPrefs.Save();
        
        ApplyButtonEffects();
    }

    private void ApplyButtonEffects()
    {
        Image imageComponent = image.GetComponent<Image>();
        Image buttonImage = button.GetComponent<Image>();
        
        imageComponent.color = new Color(255, 255, 255, 255);
        Destroy(gameObject.GetComponent<Button>());
        buttonImage.color = new Color(255, 255, 255, 0);
    }

    public void ResetButtonState()
    {
        // Сбрасываем состояние только для конкретной кнопки
        PlayerPrefs.DeleteKey("ButtonPressed_" + buttonID);
        PlayerPrefs.Save();
        
        // Возвращаем изображению исходную видимость
        Image imageComponent = image.GetComponent<Image>();
        imageComponent.color = new Color(1, 1, 1, 1);
        
        // Добавляем компонент Button обратно, если он был удален
        if (gameObject.GetComponent<Button>() == null)
        {
            gameObject.AddComponent<Button>();
        }
    }

    public void ResetAllButtons()
    {
        // Используем новый метод FindObjectsByType
        DailyMoney[] allButtons = FindObjectsByType<DailyMoney>(FindObjectsSortMode.None);
        
        // Сбрасываем состояние каждой кнопки
        foreach (DailyMoney button in allButtons)
        {
            button.ResetButtonState();
        }
    }

    // Опционально, для сброса по нажатию клавиши
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAllButtons();
        }
    }
}
