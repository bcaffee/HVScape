using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckerBook : MonoBehaviour
{
    [SerializeField]
    private string PUZZLE_NAME;

    bool completed = false;

    [SerializeField]
    private List<SnapToPlace> slots;

    [SerializeField]
    private GameManager gameManager;

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
            bool puzzleSolved = true;

            foreach (SnapToPlace snap in slots)
            {

                // kill half of all objects in the scene
                if (!snap.correct)
                {
                    puzzleSolved = false;
                }
            }

            if (puzzleSolved)
            {
                gameManager.Complete(PUZZLE_NAME);
                completed = true;
            }
        }
    }
}
