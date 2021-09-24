using UnityEngine;
using UnityEngine.UI;

public class Weight_Detector : MonoBehaviour {

    [SerializeField]
    private Text WeightText;
    private float SideWeight = 0;
    public bool win = false;
    void Start()
    {
        while (!SideWinCondition(SideWeight));
    }

    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "atoms")
        {
            float weight = (col.gameObject.GetComponent<Rigidbody>()).mass; //getting mass //this can be repeated inside the give mass
            SideWeight += weight; //compiling the current weight on collison

            WeightText.text = "" + SideWeight; //printing to the respective textbox

            if (SideWinCondition(SideWeight) == true)
            {
                win = true;
                //Debug.Log(".Win");
            }
            else
            {
                win = false;
            }

        }
    }

    void OnCollisionExit(Collision col)
    {
        float weight = col.gameObject.GetComponent<Rigidbody>().mass; //getting mass //this can be repeated inside the give mass
        SideWeight -= weight; //compiling the current weight on collison
        if (SideWeight < 1)
        {
            SideWeight = 0;
        }
        WeightText.text = "" + SideWeight; //printing to the respective textbox
        if (SideWinCondition(SideWeight) == true)
        {
            win = true;
           //Debug.Log("Win");

        }
        else
        {
            win = false;
        }
    }

    private static bool SideWinCondition(float SideWeight)
    {
        bool done = false;
        if (atomCreator.OverallWeight / 2 == SideWeight)
        {
            done = true;
        }

        return done;

    }
}