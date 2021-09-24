using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public Text timertext;

    [SerializeField]
    private float gameTime;

    [SerializeField]
    private float timeLeft;

    [SerializeField]
    public bool gamePaused;

    // Use this for initialization
    void Start()
    {
        // Start timer
        timeLeft = gameTime;
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer code
        if (!gamePaused && timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (gamePaused)
        {
            Debug.Log("Paused");
        }
        else
        {
            timeLeft = 0f;
            Debug.Log("Time Up!");
        }

        // Change text value on canvas
        // TODO: move to watch
        string minSec = string.Format("{0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60);
        timertext.text = minSec;
    }
}
