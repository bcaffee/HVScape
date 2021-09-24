using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LiquidBehavior : MonoBehaviour
{
    /*A = 0
     * B = 1
     * C = 2
     * D = 3
     * E = 4
     * AB = (0,1),(1,0)
     * AC = (0,2),(2,0)
     * AD = (0,3),(3,0)
     * AE = (0,4),(4,0)
     * BC = (1,2),(2,1)
     * BD = (1,3),(3,1)
     * CD = (2,3),(3,2)
     * CE = (2,4),(4,2)
     * DE = (3,4),(4,3)
     * 
     */

    [SerializeField]
    private string chemicalPath;

    void Start()
    { }
    /*Chemical myChem;
    myChem = JsonUtility.FromJson<Chemical>(chemicalPath);
    Debug.Log(myChem.name);
}*/

    void OnCollisionEnter(Collision col)
    {
        CombinationChecker(col.gameObject, gameObject);
    }

    public void CombinationChecker(GameObject collision, GameObject current)
    {
        if (collision.tag.Length == 1 && current.tag.Length == 1)
        {
            string newTag = collision.tag + current.tag;

            if (collision.tag.Equals("A") && current.tag.Equals("B"))
            {
                collision.transform.GetComponent<Renderer>().material.color = Color.gray;
                transform.GetComponent<Renderer>().material.color = Color.gray;
                collision.gameObject.tag = newTag;
                current.gameObject.tag = newTag;
            }
            else if (collision.tag.Equals("A") && current.tag.Equals("C"))
            {
                collision.transform.GetComponent<Renderer>().material.color = Color.cyan;
                transform.GetComponent<Renderer>().material.color = Color.cyan;
                collision.gameObject.tag = newTag;
                current.gameObject.tag = newTag;

            }
            /*else if (collision.name.Contains("A") && current.name.Contains("D"))
            {
                collision.transform.GetComponent<Renderer>().material.color = Color.cyan;
                collision.gameObject.tag = "AD";
                transform.GetComponent<Renderer>().material.color = Color.cyan;
                current.gameObject.tag = "AD";
            }*/
            else if (collision.tag.Equals("B") && current.tag.Equals("C"))
            {
                collision.transform.GetComponent<Renderer>().material.color = Color.white;
                transform.GetComponent<Renderer>().material.color = Color.white;
                collision.gameObject.tag = newTag;
                current.gameObject.tag = newTag;
            }
            
        }
        if (collision.tag.Length == 2 && current.tag.Length == 1)
        {
            if (collision.tag.Contains(current.tag))
            {
                current.transform.GetComponent<Renderer>().material.color = collision.GetComponent<Renderer>().material.color;
                gameObject.tag = collision.tag;
            }


            //if that tag matches a name in the chemical colors get color
            //collision.transform.GetComponent<Renderer>().material.color = color from chemicallist;
            //transform.GetComponent<Renderer>().material.color = color from chemicallist;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

    /*[Serializable]
    public class Chemical
    {
        public Chemical() { }
        
        public string name { get; set; }
        public string colorid { get; set; }
    }
        
    }*/
