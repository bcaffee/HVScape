using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    [SerializeField]
    private int rotations = 8;

    [SerializeField]
    private float xOffset;

    [SerializeField]
    private float yOffset;

    [SerializeField]
    private float heightOffset;

    [SerializeField]
    private float rotOffset;

    [SerializeField]
    private int gridSize;

    private List<List<GameObject>> GameObjects;

    [SerializeField]
    private List<GameObject> prefabList;

    [SerializeField]
    private List<GameObject> puzzleList;

    public bool hasRun;
    public bool puzzle;
    void Start()
    {
        Generate();
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void Generate()
    {
        puzzle = false;
        System.Random rand = new System.Random();
        GameObjects = new List<List<GameObject>>();

        Debug.Log("Grid: " + gridSize);
        // Loop through Array and place
        for (int x = 0; x < gridSize; x++)
        {
            Debug.Log("Outer Loop: " + x);
            for (int y = 0; y < gridSize; y++)
            {
                Debug.Log("Inner Loop: " + y);
                float xPos = 0;
                float yPos = 0;
                if (y == 0 && x == 0)
                {
                    xPos = (0);
                    yPos = (0);
                }
                else
                {
                    xPos = x * xOffset;
                    yPos = y * yOffset;
                }
                Vector3 pos = new Vector3(xPos, 0 + heightOffset, yPos);


                // Create prefab
                int val = rand.Next(1, 3);
                if (val == 1 && !puzzle)
                {
                    Debug.Log("Creating new puzzle: " + val);
                    puzzle = true;
                    GameObject obj = RandomPuzzle();
                    obj = Instantiate(obj, pos, Quaternion.identity);
                    SetLayerRecursively(obj, 2);
                    raycast(obj);
                }
                else
                {
                    Debug.Log("Creating new: " + val);
                    GameObject obj = RandomFurinture();
                    obj = Instantiate(obj, pos, Quaternion.identity);
                    SetLayerRecursively(obj, 2);
                    raycast(obj);
                    // GameObjects[x].Add(obj);
                }

                Debug.Log("End of Inner Loop: " + y);

            }
            Debug.Log("End of Outer Loop: " + x);
        }
    }

    GameObject RandomFurinture()
    {
        System.Random rand = new System.Random();
        int randnum = rand.Next(0, prefabList.Capacity);
        return prefabList[randnum];
    }

    GameObject RandomPuzzle()
    {
        System.Random rand = new System.Random();
        int randnum = rand.Next(0, puzzleList.Capacity);
        return puzzleList[randnum];
    }

    int raycast(GameObject obj)
    {
        obj.transform.eulerAngles = new Vector3(-90, 0, 0);
        float longestHit = 0.0f;
        int rot = 0;
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        for (int i = 0; i < rotations; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(obj.transform.position, obj.transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(obj.transform.position, obj.transform.TransformDirection(Vector3.left * (i * (int)rotOffset)) * hit.distance, Color.yellow);
                Debug.Log(hit.distance);
                if (hit.distance > longestHit)
                {
                    Debug.Log("Longest Hit: " + hit.distance);
                    rot = i * (int)rotOffset;
                    longestHit = hit.distance;
                    obj.transform.eulerAngles = new Vector3(-90, 0, rot);
                    Debug.Log(obj.transform.rotation);
                }
            }
            else
            {
                Debug.DrawRay(obj.transform.position, obj.transform.TransformDirection(Vector3.forward * (i * (int)rotOffset)) * 1000, Color.red);
            }

        }
        return rot;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(1); //or whatever number your scene is
    }
}