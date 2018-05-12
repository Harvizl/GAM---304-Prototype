using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public Transform myTransform;
    public GameObject powerUpPrefab;
    public GameObject[] explosions = new GameObject[2];

    float speed = 10f;

    public static bool animTwo;
    public static bool animThree;

    public static bool lastShrimp;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        

        lastShrimp = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys object when off screen
        if (transform.position.x < -14)
        {
            Destroy(gameObject);
        }

        // Animation for Wave 1
        if (animThree)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_3");
        }
        else if (animTwo)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_2");
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_1");
        }

        //myTransform.position += transform.forward * 10 * Time.deltaTime;
        //Vector3 currentPosition = transform.position;
        //currentPosition.y += speed * Time.deltaTime;
        //currentPosition.x += -10f * Time.deltaTime;
        //transform.position = currentPosition;

        // Changing direction
        /*if (currentPosition.y < 0f)
        {
            // Move up
            speed = Mathf.Abs(speed);
        }
        else if (currentPosition.y > 6)
        {
            // Move down
            speed = -Mathf.Abs(speed);
        }*/


        //transform.rotation = Quaternion.Euler(currentPosition.x * 80, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Bullet")
        {
            health--;
            Destroy(other.gameObject);

            if (health == 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
        GameObject powerUp = Instantiate(powerUpPrefab);
        powerUp.transform.position = transform.position;

        Instantiate(explosions[0], transform.position, Quaternion.identity);
        //Plane.enemyKills[0]++;
        // Parse the text of the scoreGT into an int
        int score = int.Parse(Main.scoreGT.text);
        score += 100;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();
    }
}
