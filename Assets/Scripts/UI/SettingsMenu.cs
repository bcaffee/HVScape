using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //If default settings are on then when switched off the previous values for the settings will be used
    [SerializeField]
    private Button ResetSettingsToDefault;

    [SerializeField]
    private Button BackBtn;

    [SerializeField]
    private Toggle HandSide;

    void Start()
    {
        MainMenu.CurrentPanelName = "Settings";
        this.HandSide.isOn = true;
        ResetSettings();
    }

    void Update()
    {
        this.HandSide.isOn = true; //Right Hand default
        ResetSettings();
    }

    public void ResetSettings()
    {
        SettingsManager.Volume = SettingsManager.DEFAULT_VOLUME;
        SettingsManager.HandSide = this.HandSide.isOn;

        Debug.Log("Settings have been reset.");
    }

    public void SwitchHand()
    {
        SettingsManager.HandSide = !this.HandSide.isOn;

        Debug.Log("Hands just switched.");
    }
}