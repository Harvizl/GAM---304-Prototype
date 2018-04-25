using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Waves
{
    shrimp_1, shrimp_2, shrimp_3
}

public class Shrimp : MonoBehaviour
{
    public int health = 1;

    public Transform myTransform;
    public GameObject powerUpPrefab;
    public GameObject explosion;

    float speed = 10f;

    public static bool animTwo;
    public static bool animThree;

    public static bool lastShrimp;

    // Use this for initialization
    void Start()
    {
        SetWave();

        myTransform = transform;

        // Animation for Wave 1 **SLOW IT DOWN**
        /*if (animThree)
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
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys object when off screen
        if (transform.position.x < -14)
        {
            Destroy(gameObject);
        }
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

        Instantiate(explosion, transform.position, Quaternion.identity);

        // Parse the text of the scoreGT into an int
        int score = int.Parse(Main.scoreGT.text);
        score += 100;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();
    }

    void SetWave()
    {
        if (Main.waves == Waves.shrimp_1)

            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_1");

        else if (Main.waves == Waves.shrimp_2)
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_2");
        else
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_3");
    }
}
