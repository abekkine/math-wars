using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

    private Canvas mainMenu = null;
    private Button mainMenuPlay = null;
    private Button mainMenuStats = null;
    private Button mainMenuExit = null;

    private Canvas exitConfirmMenu = null;
    private Button exitConfirmYes = null;
    private Button exitConfirmNo = null;

    private Canvas inGameMenu = null;


    // Use this for initialization
    void Awake () {
	    switch (Application.loadedLevel)
        {
            case 0: // Main Menu
                setupMainMenu();
                break;
            case 1: // In Game Menu
                setupInGameMenu();
                break;
        }
	}

    private void setupMainMenu()
    {
        // Find main menu
        mainMenu = GameObject.Find("/MainMenu").GetComponent<Canvas>();
        // Find options
        mainMenuPlay = GameObject.Find("/MainMenu/Play").GetComponent<Button>();
        mainMenuStats = GameObject.Find("/MainMenu/Stats").GetComponent<Button>();
        mainMenuExit = GameObject.Find("/MainMenu/Exit").GetComponent<Button>();

        // Find confirm dialog
        exitConfirmMenu = GameObject.Find("/ConfirmMenu").GetComponent<Canvas>();
        // Find options
        exitConfirmMenu.enabled = false;
        exitConfirmYes = GameObject.Find("/ConfirmMenu/Yes").GetComponent<Button>();
        exitConfirmNo = GameObject.Find("/ConfirmMenu/No").GetComponent<Button>();
    }

    private void setupInGameMenu()
    {

    }

    public void MainMenuPlay()
    {
        Application.LoadLevel(1);
    }

    public void MainMenuStats()
    {
        Application.LoadLevel(2);
    }

    public void MainMenuExit()
    {
        exitConfirmMenu.enabled = true;

        mainMenuPlay.interactable = false;
        mainMenuStats.interactable = false;
        mainMenuExit.interactable = false;
    }

    public void ExitConfirmYes()
    {
        Application.Quit();
    }

    public void ExitConfirmNo()
    {
        exitConfirmMenu.enabled = false;

        mainMenuPlay.interactable = true;
        mainMenuStats.interactable = true;
        mainMenuExit.interactable = true;
    }

    public void InGameToMenu()
    {
        Application.LoadLevel(0);
    }

    public void StatsToMenu()
    {
        Application.LoadLevel(0);
    }
}
