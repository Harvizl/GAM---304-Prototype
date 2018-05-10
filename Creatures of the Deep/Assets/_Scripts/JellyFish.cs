using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : MonoBehaviour {

    public int health = 10;

    public GameObject explosion;
    public GameObject powerUpPrefab;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Animator>().Play("JellyFish");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y == 10)
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

            if (health == 0)
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
            GameObject powerUp = Instantiate(powerUpPrefab);
            powerUp.transform.position = transform.position;
        }
    }
}
