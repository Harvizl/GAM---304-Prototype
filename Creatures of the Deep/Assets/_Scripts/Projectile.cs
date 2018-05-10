using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioSource[] sounds = new AudioSource[5];
    public Transform plane;
    public float yAxis;
    
    void Start()
    {
        sounds[0] = GameObject.Find("Enemy_Explosion").GetComponent<AudioSource>();
        
        sounds[1] = GameObject.Find("Enemy_Hit").GetComponent<AudioSource>();

        plane = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        yAxis = plane.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 14)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= -14)
        {
            Destroy(gameObject);
        }

        transform.rotation = Quaternion.FromToRotation(plane.position, plane.position);
        //transform.rotation = Quaternion.LookRotation(gameObject.GetComponent<Rigidbody>().velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains ("Prawn") || other.tag.Contains ("Shrimp") || other.tag.Contains ("Jelly Fish"))
        {
            sounds[0].Play();
        }
        if(other.tag.Contains ("Pacu") || other.tag.Contains ("Switch"))
        {
            sounds[1].Play();
        }
        if (other.tag == "Switch")
        {
            Switches.hp--;
            Destroy(gameObject);
            Debug.Log(Switches.hp.ToString());

        }
    }
}





