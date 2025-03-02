using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    public RectTransform menuPanel;
    public float slideSpeed = 500f;
    public float topPosition = 0f;      // Позиция когда меню открыто
    public float bottomPosition = -200f; // Позиция когда меню закрыто
    private bool isShowing = false;
    private bool isAnimating = false;    // Флаг для предотвращения множественных анимаций
    
    void Start()
    {
        // Устанавливаем начальную позицию меню внизу
        menuPanel.anchoredPosition = new Vector2(menuPanel.anchoredPosition.x, bottomPosition);
    }

    public void ToggleMenu()
    {
        if (isAnimating) return; // Предотвращаем множественные нажатия во время анимации
        
        isShowing = !isShowing;
        float targetPosition = isShowing ? topPosition : bottomPosition;
        StartCoroutine(SlideMenu(targetPosition));
    }

    private IEnumerator SlideMenu(float targetPosition)
    {
        isAnimating = true;

        while (Mathf.Abs(menuPanel.anchoredPosition.y - targetPosition) > 0.1f)
        {
            float newY = Mathf.MoveTowards(menuPanel.anchoredPosition.y, 
                                         targetPosition, 
                                         slideSpeed * Time.deltaTime);
                                         
            menuPanel.anchoredPosition = new Vector2(menuPanel.anchoredPosition.x, newY);
            yield return null;
        }

        // Устанавливаем точную конечную позицию
        menuPanel.anchoredPosition = new Vector2(menuPanel.anchoredPosition.x, targetPosition);
        isAnimating = false;
    }
} 