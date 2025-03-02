using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private Color validColor = Color.green;
    [SerializeField] private Color invalidColor = Color.red;

    private GameObject currentBuilding;
    private SpriteRenderer previewRenderer;
    private bool isPlacing = false;

    void Update()
    {
        if (isPlacing)
        {
            UpdateBuildingPosition();
            CheckPlacementValidity();
            HandleInput();
        }
    }

    public void StartPlacingBuilding(GameObject prefab)
    {
        currentBuilding = Instantiate(prefab);
        previewRenderer = currentBuilding.GetComponent<SpriteRenderer>();
        previewRenderer.color = new Color(1, 1, 1, 0.5f); // Полупрозрачность
        isPlacing = true;
    }

    private void UpdateBuildingPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currentBuilding.transform.position = mousePos;
    }

    private void CheckPlacementValidity()
    {
        // Добавьте проверку коллизий при необходимости
        previewRenderer.color = validColor;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previewRenderer.color = Color.white;
            isPlacing = false;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentBuilding);
            isPlacing = false;
        }
    }
}