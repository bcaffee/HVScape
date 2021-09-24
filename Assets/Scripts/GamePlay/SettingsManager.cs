using UnityEngine;
using UnityEngine.Audio;

public static class SettingsManager : object
{

    public const int DEFAULT_VOLUME = 50;

    public static float Volume { get; set; }

    //public static bool SettingsDefault { get; set; }

    public static bool HandSide { get; set; }

    public static AudioSource MenuMusic { get; set; }

    public static AudioSource GameMusic { get; set; }

    /*
     void Start()
    {

        MenuMusic.Play();

        //Assign Default values
        Volume = DEFAULT_VOLUME;

        MenuMusic.volume = Volume;
    }
     */
}