using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShrimpWaves
{
	wave_1,
	wave_2,
	wave_3
}

public class Shrimp : MonoBehaviour
{
    public int health = 1;

	public GameObject explosion;
    public Transform myTransform;
	public GameObject powerUpPrefab;

    // Use this for initialization
    void Start()
    {
        SetWave();

        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x <= -14.5f || transform.position.x >= 14.5f)
		{
			Destroy (gameObject);
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
		if (gameObject.tag == "Enemy Last")
		{
			GameObject powerUp = Instantiate (powerUpPrefab);
			powerUp.transform.position = transform.position;
		}

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
		if (Main.shrimpWaves == ShrimpWaves.wave_1)

            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_1");

        else if (Main.shrimpWaves == ShrimpWaves.wave_2)
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_2");
        else
            gameObject.GetComponent<Animator>().SetTrigger("Shrimp_3");
    }
}
