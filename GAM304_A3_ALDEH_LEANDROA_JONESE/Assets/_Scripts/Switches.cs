﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Switches : MonoBehaviour
{
    public static int hp;
    public GameObject explosion;

	public GameObject door;

    // Use this for initialization
    void Start()
    {
        hp = 7;
		door = GameObject.Find ("Door");
    }

    // Update is called once per frame
    void Update()
    {        
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

        if (hp <= 0)
        {
            Destroyed();

        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

		door.GetComponentInChildren<Animator> ().SetTrigger ("Unlocked");
    }      
}
