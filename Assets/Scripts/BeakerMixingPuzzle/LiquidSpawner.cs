using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject ChemicalAPrefab;
    [SerializeField]
    private GameObject ChemicalBPrefab;
    [SerializeField]
    private GameObject ChemicalCPrefab;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

        float zOffset = -3.041f;
        float yOffset = .5f;
        for (int n = 0; n < 6; n++)
        {
            zOffset += .005f;
            yOffset += .005f;

            GameObject ChemicalA = Instantiate(ChemicalAPrefab);
            GameObject ChemicalB = Instantiate(ChemicalBPrefab);
            GameObject ChemicalC = Instantiate(ChemicalCPrefab);

            ChemicalA.transform.position = new Vector3(0.366f, yOffset, zOffset);
            ChemicalB.transform.position = new Vector3(0.223f, yOffset + .5f, zOffset);
            ChemicalC.transform.position = new Vector3(0.263f, yOffset - .5f, zOffset);
        }
    }
    public void SpawnObject()
    {
        Instantiate(ChemicalAPrefab, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
