using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class isDeactiveTeleport : MonoBehaviour
{
    public PostProcessingProfile nonvingette;

    public GameObject VRCamera;

    // Use this for initialization
    void Start()
    {
        // Change the profile
        VRCamera.GetComponent<PostProcessingBehaviour>().profile = nonvingette;
    }
}
