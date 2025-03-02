using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isButtonPressed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null; // Отсоединяем от родителя, делаем корневым объектом
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetButtonPressed()
    {
        isButtonPressed = true;
        Debug.Log("Кнопка нажата, состояние сохранено");
    }
} 