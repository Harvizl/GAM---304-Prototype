using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Switches : MonoBehaviour
{
    public static int hp;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        hp = 7;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp.ToString());
        /*if (health == 0)
        {
            Destroyed();
        }
        if(Plane.buffCounts[0] == 0)
        {
            health = 5;
        }
        else if (Plane.buffCounts[0] == 1)
        {
            health = 
        }*/

        if (hp == 0)
        {
            Destroyed();
        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        //Animate Door
    }      
}
