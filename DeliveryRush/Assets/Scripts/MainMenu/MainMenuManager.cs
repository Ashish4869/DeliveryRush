using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    ///
    /// Deals with Main Menu functions
    ///

    [SerializeField]
    GameObject LevelSelect;

    [SerializeField]
    GameObject MainMenu;

    LevelSelectManager _levelSelectManager;

  

    public void ShowLevelSelect()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
        _levelSelectManager = FindObjectOfType<LevelSelectManager>();
        _levelSelectManager.ConfigureLevels();
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
