using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckerPlug : MonoBehaviour
{
    [SerializeField]
    private string PUZZLE_NAME;

    public bool completed = false;

    [SerializeField]
    private List<AmIPowered> plugs;

    [SerializeField]
    private GameManager gameManager;

    void Start()
    {
        gameManager.Register(PUZZLE_NAME);
    }

    void FixedUpdate()
    {
        //Debug.Log("Runs loop");
        if (!completed)
        {
            bool puzzleSolved = true;

            foreach (AmIPowered power in plugs)
            {
                

                if (!power.powered)
                {
                    puzzleSolved = false;
                }
            }

            if (puzzleSolved)
            {
                gameManager.Complete(PUZZLE_NAME);
                completed = true;
                this.gameObject.GetComponent<Light>().enabled = true;
                Debug.Log("Powerstrip puzzle is solved");
            }
        }
    }
}
