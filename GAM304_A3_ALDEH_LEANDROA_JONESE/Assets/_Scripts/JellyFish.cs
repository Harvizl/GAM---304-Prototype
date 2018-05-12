using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour {

    public int health = 3;

    public GameObject explosion;

    // [0] = shootSpeedBuff
    // [1] = movementSpeedBuff
    // [2] = twinShotBuff
    // [3] = shieldBuff
    public GameObject[] buffs = new GameObject[4];
    public GameObject[] liveBuffs = new GameObject[4];

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        liveBuffs[0] = GameObject.FindGameObjectWithTag("Shoot Speed Buff");
        liveBuffs[1] = GameObject.FindGameObjectWithTag("Movement Speed Buff");
        liveBuffs[2] = GameObject.FindGameObjectWithTag("Twin Shot");
        liveBuffs[3] = GameObject.FindGameObjectWithTag("Shield Buff");

        if (transform.position.y >= 9.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Bullet")
        {
            print("Hit");
            health--;
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);

            if (health <= 0)
            {
                print("Dead");
                Death();
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
        Main.jellyFishCount++;
        Instantiate(explosion, transform.position, Quaternion.identity);

        // Parse the text of the scoreGT into an int
        int score = int.Parse(Main.scoreGT.text);
        score += 100;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();

        if (Main.jellyFishCount >= 3 && Plane.shield == false)
        {
            Main.jellyFishCount = 0;

            if (liveBuffs[3] == null)
            {
                GameObject shield = Instantiate(buffs[3]);
                shield.transform.position = transform.position;
            }
        }
        else if (Main.jellyFishCount >= 3 && Plane.shield)
        {
            Main.jellyFishCount = 0;
            if (liveBuffs[2] == null)
            {
                GameObject twinShot = Instantiate(buffs[2]);
                twinShot.transform.position = transform.position;
            }
        }
        else if (Plane.shield && Plane.twinBuff)
        {
            Main.jellyFishCount = 0;
        }
    }
}
