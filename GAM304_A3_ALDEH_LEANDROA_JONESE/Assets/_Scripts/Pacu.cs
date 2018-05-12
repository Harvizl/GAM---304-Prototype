using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacu : MonoBehaviour {

    public GameObject[] sounds = new GameObject[2];
    public GameObject[] explosions = new GameObject[2];

    public GameObject enemyBullet;

    public int health = 50;

    // Bullet spawn point
    public Vector3 tempPos;

    // [0] = shootSpeedBuff
    // [1] = movementSpeedBuff
    // [2] = twinShotBuff
    // [3] = shieldBuff
    public GameObject[] buffs = new GameObject[4];

    // Use this for initialization
    void Start () {
        sounds[0] = GameObject.Find("Enemy_Explosion");
        sounds[1] = GameObject.Find("Enemy_Fire");

        StartCoroutine(DualShot());
        GetComponent<Animator>().SetTrigger("Pacu");
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Death();
        }

        tempPos = transform.position;
        tempPos.x = tempPos.x + 1;
        tempPos.y = tempPos.y - 0.45f;
        enemyBullet.transform.position = tempPos;
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
        sounds[1].GetComponent<AudioSource>().Play();
        GameObject bullet = Instantiate(enemyBullet, enemyBullet.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.left * 50f;
        yield return new WaitForSeconds(0.3f);
        sounds[1].GetComponent<AudioSource>().Play();
        GameObject bullet2 = Instantiate(enemyBullet, enemyBullet.transform.position, Quaternion.identity) as GameObject;
        bullet2.GetComponent<Rigidbody>().velocity = Vector3.left * 50f;
        StartCoroutine(DualShot());
    }

    void Death()
    {
        Main.pacuCount++;
        Destroy(gameObject);


        if (Plane.shield == false)
        {
            GameObject powerUp = Instantiate(buffs[3], transform.position, Quaternion.identity);
            powerUp.transform.position = transform.position;
            sounds[0].GetComponent<AudioSource>().Play();
        }
        else if (Plane.shield)
        {
            GameObject powerUp = Instantiate(buffs[2]);
            powerUp.transform.position = transform.position;
            sounds[0].GetComponent<AudioSource>().Play();
        }
        else if (Plane.shield)
        {
            if (Plane.twinBuff)
            {
                sounds[0].GetComponent<AudioSource>().Play();
            }
        }

            // Parse the text of the scoreGT into an int
            int score = int.Parse(Main.scoreGT.text);
        score += 500;

        // Convert the score back to a string and display it
        Main.scoreGT.text = score.ToString();
    }
}
