﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int health = 2;
    public Transform myTransform;
    public GameObject powerUpPrefab;
    public GameObject[] explosions = new GameObject[2];

    float speed = 10f;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys object when off screen
        if (transform.position.x < -14)
        {
            Destroy(gameObject);
        }

        //myTransform.position += transform.forward * 10 * Time.deltaTime;
        Vector3 currentPosition = transform.position;
        currentPosition.y += speed * Time.deltaTime;
        currentPosition.x += -10f * Time.deltaTime;
        transform.position = currentPosition;

        // Changing direction
        if (currentPosition.y < -6)
        {
            // Move up
            speed = Mathf.Abs(speed);
        }
        else if (currentPosition.y > 0f)
        {
            // Move down
            speed = -Mathf.Abs(speed);
        }
        transform.rotation = Quaternion.Euler(currentPosition.x * 80, 0, 0);
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
        Instantiate(explosions[0], transform.position, Quaternion.identity);
        
        // Parse the text of the scoreGT into an int
        int score = int.Parse(Main.scoreGT.text);
        score += 100;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();
    }
}
