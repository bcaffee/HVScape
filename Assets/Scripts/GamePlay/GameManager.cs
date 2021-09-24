using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    bool DEBUG = false;

    [SerializeField]
    int level;

    [SerializeField]
    CallbackType callback;

    [SerializeField]
    string scenename;

    // When true check all puzles
    bool changed;

    public enum CallbackType
    {
        ReloadScene, HomeScene
    }

    private Dictionary<string, bool> puzzles = new Dictionary<string, bool>();

    private static GameManager gm;

    private void Awake()
    {
        // Save object on load
        DontDestroyOnLoad(this);

        // only one in scene
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        changed = false;
        // Set callback type if not already defined
        callback = (callback == null ? CallbackType.ReloadScene : callback);

        // Initialize fields
        level = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("Changed: " + changed);
        // Check if level is done
        if (changed)
        {
            LevelCheck();
        }
    }

    // Set the callback type of this gamemanager
    public void SetCallback(CallbackType cb)
    {
        this.callback = cb;
    }

    // Mark a puzzle as complete    
    public void Complete(string name)
    {
        Debug.Log("Completed Puzzle: " + name);
        this.puzzles[name] = true;
        changed = true;
    }

    // Add a puzzle to the puzzle Dictionary 
    public void Register(string name)
    {
        this.puzzles.Add(name, false);
        if (DEBUG)
        {
            Debug.Log("Registered Puzzle: " + name);
        }
    }

    // Checks the level and updates
    void LevelCheck()
    {
        if (DEBUG)
        {
            Debug.Log("Checking puzzles");
        }
        bool alldone = true;

        // Check if any puzzles are not done
        foreach (KeyValuePair<string, bool> pair in this.puzzles)
        {
            if (DEBUG)
            {
                Debug.Log("KEY: " + pair.Key);
                Debug.Log("VALUE: " + pair.Value);
            }

            if (pair.Value == false)
            {
                alldone = false;
            }
        }

        // Check if user finished level
        if (alldone)
        {
            // Move to next level
            this.level++;

            // Reload the scene/Home
            switch (this.callback)
            {
                case CallbackType.HomeScene:
                    // TODO: Dynamically choose home scene
                    SceneManager.LoadScene(1);
                    break;

                case CallbackType.ReloadScene:
                    ReloadScene();
                    break;

                default:
                    Debug.Log("This should never happen!");
                    break;
            }
        }

        // Reset check
        changed = false;
    }

    // Reload the current scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(this.scenename);
    }
}