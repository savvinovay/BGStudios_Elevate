using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayExit : MonoBehaviour
{
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void StartMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectCityPressed()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsPressed()
    {
        SceneManager.LoadScene(2);
    }
    public void SandboxPressed()
    {
        SceneManager.LoadScene(3);
    }
    public void City1Pressed()
    {
        SceneManager.LoadScene(4);
    }
    public void City2Pressed()
    {
        SceneManager.LoadScene(5);
    }
    public void FriendsPressed()
    {
        SceneManager.LoadScene(6);
    }
    public void AddFriendsPressed()
    {
        SceneManager.LoadScene(7);
    }
    public void AchievmentsPressed()
    {
        SceneManager.LoadScene(8);
    }
    public void DarkSettings()
    {
        SceneManager.LoadScene(9);
    }
    public void DarkMenu()
    {
        SceneManager.LoadScene(10);
    }
    public void DarkProfile()
    {
        SceneManager.LoadScene(11);
    }
    public void DarkStore()
    {
        SceneManager.LoadScene(12);
    }
    public void DarkDaily()
    {
        SceneManager.LoadScene(13);
    }
    public void DarkGovno()
    {
        SceneManager.LoadScene(14);
    }
    public void DarkDay()
    {
        SceneManager.LoadScene(15);
    }
    public void HabitsRegularHarm()
    {
        SceneManager.LoadScene(16);
    }
    public void HabitsName()
    {
        SceneManager.LoadScene(17);
    }
}
