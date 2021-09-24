using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject AtomPrefab;

    private static readonly int[] values = { 1, 6, 7, 8 };
    public static float OverallWeight;
    // Use this for initialization
    void Start()
    {
        int[] selected = new int[5];
        do
        {
            for (int n = 0; n < selected.Length; n++)
            {
                selected[n] = values[Random.Range(0, values.Length)];
            }

        } while (!Compare(selected));
        assigner(selected);
    }

    private static bool Compare(int[] numbers)
    {
        bool done = false;
        for (int i = 0; i < (numbers.Length - 1); i++) //doesn't need to go to the last one
        {
            int currentValue = numbers[i];
            for (int j = i + 1; j < numbers.Length; j++) //doesn't need to start at i
            {
                int newValue = currentValue + numbers[j];
                int compareValue = 0;
                for (int k = 0; k < numbers.Length; k++)
                {
                    if ((k != i) && (k != j))
                    {
                        compareValue += numbers[k];
                    }
                }
                if (newValue == compareValue)
                {
                    done = true;
                    return done;
                }
            }
        }
        return done;
    }

    void assigner(int[] numbers)
    {
        int oxygen = 8;
        int nitrogen = 7;
        int carbon = 6;
        int hydrogen = 1;
        Rigidbody rb;
        float offset = -.375f;


        for (int n = 0; n < numbers.Length; n++)
        {
            GameObject ap = Instantiate(AtomPrefab, this.transform);
            rb = ap.GetComponent<Rigidbody>();
            offset += .125f;
            if (numbers[n] == oxygen)
            {
                //spawn oxygen -- red
                ap.GetComponent<Renderer>().material.color = Color.red;
                rb.mass = oxygen;
            }
            else if (numbers[n] == nitrogen)
            {
                //spawn nitrogen -- purple
                ap.GetComponent<Renderer>().material.color = Color.magenta;
                rb.mass = nitrogen;
            }
            else if (numbers[n] == carbon)
            {
                //spawn carbon -- black
                ap.GetComponent<Renderer>().material.color = Color.black;
                rb.mass = carbon;

            }
            else
            {
                //spawn hydrogen -- white
                ap.GetComponent<Renderer>().material.color = Color.white;
                rb.mass = hydrogen;
                
            }
            OverallWeight += rb.mass;
            ap.transform.position = new Vector3(this.transform.position.x + offset, this.transform.position.y + .5f, this.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
