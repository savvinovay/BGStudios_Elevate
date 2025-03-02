using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetButtonPressed();
        }
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}