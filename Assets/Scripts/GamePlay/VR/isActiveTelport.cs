using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class isActiveTelport : MonoBehaviour
{
    public PostProcessingProfile vingette;

    public GameObject VRCamera;

    // Use this for initialization
    void Start()
    {
        // Change the profile
        VRCamera.GetComponent<PostProcessingBehaviour>().profile = vingette;
    }
}