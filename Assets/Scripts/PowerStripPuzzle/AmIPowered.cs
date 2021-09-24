using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIPowered : MonoBehaviour
{
    [SerializeField]
    private GameObject myCord;

    [SerializeField]
    public Material hasPower;

    [SerializeField]
    public Material noPower;

    public bool powered = false;

    void winCondition()
    {
        PowerChecker myPower = myCord.GetComponent<PowerChecker>();
        if (myPower.on == true && powered == false)
        {
            GetComponent<Renderer>().material = hasPower;
            powered = true;
        }
        else if (myPower.on == false)
        {
            GetComponent<Renderer>().material = noPower;
            powered = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        winCondition();
    }
}
