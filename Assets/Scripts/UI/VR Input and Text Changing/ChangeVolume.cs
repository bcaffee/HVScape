using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{

    [SerializeField]
    private Text VolumeText;

    [SerializeField]
    private readonly Slider VolumeSlider;

    void Start()
    {
        VolumeText = GetComponent<Text>();
    }

    public void ChangeVolumeText(float value)
    {

        //Change Text
        VolumeText.text = "Current: " + Mathf.RoundToInt(value * 100) + "%";

        //Change Volume variable
        SettingsManager.Volume = Mathf.RoundToInt(value * 100);
        //Above line may have to be changed from Mathf.RoundtoInt to just value (bec it needs to be float)

        //Change actual volume
        SettingsManager.MenuMusic.volume = SettingsManager.Volume;

        Debug.Log("Volume has been changed.");
    }
}