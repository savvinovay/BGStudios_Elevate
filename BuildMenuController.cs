using UnityEngine;
using UnityEngine.UI;

public class BuildMenuController : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private GameObject buildMenuPanel;
    [SerializeField] private Button openMenuButton;
    
    [Header("Префабы зданий")]
    [SerializeField] private GameObject[] buildingPrefabs; // Добавьте префабы в инспекторе

    private BuildingPlacer buildingPlacer;

    void Start()
    {
        buildingPlacer = FindAnyObjectByType<BuildingPlacer>();
        openMenuButton.onClick.AddListener(ToggleBuildMenu);
        buildMenuPanel.SetActive(false);
    }

    public void ToggleBuildMenu()
    {
        buildMenuPanel.SetActive(!buildMenuPanel.activeSelf);
    }

    // Вызывается при нажатии на кнопку здания
    public void SelectBuilding(int buildingIndex)
    {
        if (buildingIndex < 0 || buildingIndex >= buildingPrefabs.Length)
        {
            Debug.LogError("Неверный индекс здания!");
            return;
        }

        if (buildingPrefabs[buildingIndex] == null)
        {
            Debug.LogError("Префаб здания не назначен!");
            return;
        }

        buildingPlacer.StartPlacingBuilding(buildingPrefabs[buildingIndex]);
        ToggleBuildMenu(); // Закрываем меню
    }
}