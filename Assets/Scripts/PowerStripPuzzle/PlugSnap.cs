using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugSnap : MonoBehaviour
{
    GameObject plug;

    bool empty = true;

    string currentTag;

    public bool completed = false;

    void Start()
    {
        //find a way to have specific shelf
        plug = gameObject;
    }

    void OnCollisionEnter(Collision col)
    {

        GameObject cord = col.gameObject;

        if (cord.tag.Contains("Cord") && empty)
        {
            cord.GetComponent<PowerChecker>().Set(true);
            Move(cord, plug);
            empty = false;
        }
    }

    void OnCollisionExit(Collision col)
    {

        GameObject cord = col.gameObject;

        if (cord.tag.Contains("Cord") && empty == false)
        {
            cord.GetComponent<PowerChecker>().Set(false);
            empty = true;
        }
    }

    void Move(GameObject cord, GameObject plug)
    {
        Vector3 pos;
        pos = plug.transform.position;
        cord.transform.position = pos;
    }

    void CorrectPlug()
    {
        if (empty == false && plug.name.Contains(name))
        {
            completed = true;
        }
    }
}