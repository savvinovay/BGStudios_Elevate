using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public Text moneyText; // Ссылка на компонент Text для отображения денег

    void Start()
    {
        UpdateMoneyDisplay();
    }

    void UpdateMoneyDisplay()
    {
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = currentMoney.ToString();
    }
}