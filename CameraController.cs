using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 0.5f;
    private Vector3 dragOrigin;

        [SerializeField] private Vector2 minBounds; // Минимальные координаты (X, Y)
        [SerializeField] private Vector2 maxBounds; // Максимальные координаты (X, Y)

        private void ClampCameraPosition()
        {
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }

    void Update()
    {
        // Обработка мыши
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.z = 0; // Фиксируем ось Z для 2D
            transform.position += direction * dragSpeed;
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Обновляем позицию
        }

        // Обработка тач-ввода
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 direction = Camera.main.ScreenToWorldPoint(touch.deltaPosition);
            direction.z = 0;
            transform.position -= direction * dragSpeed;
        }
        ClampCameraPosition();

// Вызывайте ClampCameraPosition() в конце метода Update()
    }
}