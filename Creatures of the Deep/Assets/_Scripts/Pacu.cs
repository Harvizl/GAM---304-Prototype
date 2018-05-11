using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacu : MonoBehaviour {

    public AudioSource[] sounds = new AudioSource[5];
    public GameObject[] explosions = new GameObject[2];

    public GameObject enemyBullet;
    public GameObject shieldPowerUp;

    public static int health = 50;

	// Use this for initialization
	void Start () {
        StartCoroutine(DualShot());
        GetComponent<Animator>().SetTrigger("Pacu");
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
        {
            Death();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_Bullet")
        {
            health--;
            Destroy(other.gameObject);
            Instantiate(explosions[1], transform.position, Quaternion.identity);
        }
    }

    IEnumerator DualShot()
    {
        yield return new WaitForSeconds(1);
        sounds[1].Play();
        GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.left * 50f;
        yield return new WaitForSeconds(0.3f);
        sounds[1].Play();
        GameObject bullet2 = Instantiate(enemyBullet, transform.position, Quaternion.identity) as GameObject;
        bullet2.GetComponent<Rigidbody>().velocity = Vector3.left * 50f;
        StartCoroutine(DualShot());
    }

    void Death()
    {
        Destroy(gameObject);
        sounds[0].Play();
        Instantiate(shieldPowerUp, transform.position, Quaternion.identity);

        // Parse the text of the scoreGT into an int
        int score = int.Parse(Main.scoreGT.text);
        score += 500;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();
    }
}
