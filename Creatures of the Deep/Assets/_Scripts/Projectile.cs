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
        GameObject enemyExplosionSound = GameObject.Find("Enemy_Explosion");
        sounds[0] = enemyExplosionSound.GetComponent<AudioSource>();

        GameObject enemyHitSound = GameObject.Find("Enemy_Hit");
        sounds[1] = enemyHitSound.GetComponent<AudioSource>();

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
        if (other.tag == "Enemy")
        {
            sounds[0].Play();
        }

        if (other.tag == "Enemy_Last")
        {
            sounds[0].Play();
        }

		if (other.tag == "Enemy_2")
		{
			sounds[0].Play();
		}

        if (other.tag == "Enemy_3")
        {
            sounds[0].Play();
        }

        if (other.tag == "Enemy_4")
        {
            sounds[0].Play();
        }

        if (other.tag == "Boss")
        {
            sounds[1].Play();
        }

        if (other.tag == "Switch")
        {
            sounds[1].Play();
            Switches.hp--;
            Destroy(gameObject);
            Debug.Log(Switches.hp.ToString());

        }
    }
}





