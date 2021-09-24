using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRSlider : MonoBehaviour
{
    public float FillTime = 2f;

    private Slider VolumeSlider;
    private float timer;
    private bool HandTouched;
    private Coroutine FillBarRoutine;


    void Start()
    {
        VolumeSlider = GetComponent<Slider>();
        if (VolumeSlider == null)
        {
            Debug.Log("Add a Slider component to this game object.");
        }
    }

    void Update()
    {
        
    }

    public void HandOnSlider()
    {
        HandTouched = true;
        FillBarRoutine = StartCoroutine(FillBar());
    }

    public void HandExitSlider()
    {
        HandTouched = false;
    }
    
    private IEnumerator FillBar()
    {
        timer = 0f;

        while(timer < FillTime)
        {
            timer += Time.deltaTime;

            VolumeSlider.value = timer / FillTime;

            yield return null;
        }
    }
}
