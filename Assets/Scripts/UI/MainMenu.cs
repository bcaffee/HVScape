using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //the whole Mainmenu
    [SerializeField]
    private GameObject MainMenuPanel;

    [SerializeField]
    private GameObject SettingsMenu;

    [SerializeField]
    private GameObject HowToPlayMenu;

    [SerializeField]
    private Button HowToPlayBtn;

    //volume, brightness, etc.
    private Button SettingsBtn;

    [SerializeField]
    private Button QuitBtn;

    //The name of the current active panel
    public static String CurrentPanelName { get; set; }

    void Start()
    {

    }

    public void ShowHowToPlayPanel()
    {
        HowToPlayMenu.SetActive(true);
        MainMenuPanel.SetActive(false);

        CurrentPanelName = "How to Play";

        Debug.Log("How to Play Menu activated");
    }

    public void ShowSettingsPanel()
    {
        SettingsMenu.SetActive(true);
        MainMenuPanel.SetActive(false);

        CurrentPanelName = "Settings";

        Debug.Log("Settings Menu activated");
    }

    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quitting Game");
    }

    public void MainBackHandler()
    {
        //deactivate whatever the current panel was
        switch (CurrentPanelName)
        {

            case "Settings":
                SettingsMenu.SetActive(false);
                Debug.Log("Settings Menu deactivated");
                break;

            case "How to Play":
                HowToPlayMenu.SetActive(false);
                Debug.Log("Info Menu deactivated");
                break;

            default:
                Debug.Log("This should never happen.");
                break;
        }

        //Open the main menu
        MainMenuPanel.SetActive(!MainMenuPanel.activeInHierarchy);
        Debug.Log("Now back to main menu");
    }

    /* Notes:

    https://unity3d.com/learn/tutorials/topics/virtual-reality/user-interfaces-vr
    https://unity3d.com/learn/tutorials/topics/virtual-reality/interaction-vr
    https://developer.oculus.com/blog/unitys-ui-system-in-vr/
    */
}