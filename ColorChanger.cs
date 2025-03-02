using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        CheckButtonState();
    }

    void Update()
    {
        CheckButtonState();
    }

    private void CheckButtonState()
    {
        if (GameManager.Instance != null && GameManager.Instance.isButtonPressed)
        {
            objectRenderer.material.color = Color.green;
            Debug.Log("Цвет изменен на зеленый");
        }
    }
}