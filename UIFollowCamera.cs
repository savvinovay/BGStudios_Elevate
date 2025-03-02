using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 offset; // Смещение относительно камеры

    void Update()
    {
        // Обновляем позицию UI относительно камеры
        transform.position = mainCamera.transform.position + offset;
    }
}