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
        _levelSelectManager = FindObjectOfType<LevelSelectManager>(); //Configures the levels based on the score stored in the disk
        _levelSelectManager.ConfigureLevels();
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void LoadLevel(int level)
    {
        FindObjectOfType<Transition>().LoadLevel(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
