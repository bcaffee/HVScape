using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckerScale : MonoBehaviour
{
    [SerializeField]
    private GameObject scaleOne;

    [SerializeField]
    private GameObject scaleTwo;

    [SerializeField]
    private string PUZZLE_NAME;

    [SerializeField]
    private GameManager gameManager;

    bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.Register(PUZZLE_NAME);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!completed)
        {

            Weight_Detector ofFirst = scaleOne.GetComponent<Weight_Detector>();
            Weight_Detector ofSecond = scaleTwo.GetComponent<Weight_Detector>();

            if (ofSecond.win && ofFirst.win)
            {
                completed = true;

                Debug.Log("Scale puzzle is solved");
                gameManager.Complete(PUZZLE_NAME);
            }
        }
    }
}