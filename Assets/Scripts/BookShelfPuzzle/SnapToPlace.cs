using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPlace : MonoBehaviour
{
    GameObject slot;
    bool empty = true;
    string currentTag;
    public bool correct = false;

    void Start()
    {
        //find a way to have specific shelf
        string tag = gameObject.tag;
        slot = GameObject.FindWithTag("shelf" + tag);
    }

    void OnCollisionEnter(Collision col)
    {

        GameObject collision = col.gameObject;

        if (collision.tag.Contains("book") && empty)
        {
            move(col.gameObject, slot);
            empty = false;
            currentTag = collision.tag;
            correctBook();
        }
    }

    void OnCollisionExit(Collision col)
    {
        GameObject collision = col.gameObject;
        if (collision.tag.Contains("book") && empty == false)
        {
            empty = true;
        }
    }

    void move(GameObject collision, GameObject slot)
    {
        Vector3 pos;
        Vector3 posOfBook;
        pos = slot.transform.position;
        posOfBook = collision.transform.position;
        //Debug.Log("Bookpos is " + posOfBook);
        collision.transform.position = pos;
        posOfBook = collision.transform.position;
        //Debug.Log("pos is " + pos);
        //Debug.Log("new Bookpos is " + posOfBook);
    }

    bool correctBook()
    {
        if (empty == false && currentTag.Contains(tag))
        {
            correct = true;
        }
        return correct;
    }

    void Update()
    {

    }
}