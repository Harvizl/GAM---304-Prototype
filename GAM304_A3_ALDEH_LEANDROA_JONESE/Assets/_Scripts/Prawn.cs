using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrawnWaves
{
	wave_1,
	wave_2,
	wave_3,
    wave_4,
    wave_5,
    wave_6
}

public class Prawn : MonoBehaviour
{
	public int health = 2;

	public GameObject explosion;

    // [0] = shootSpeedBuff
    // [1] = movementSpeedBuff
    // [2] = twinShotBuff
    // [3] = shieldBuff
    public GameObject[] buffs = new GameObject[4];

    // Use this for initialization
    void Start()
	{
		SetWave();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x <= -14.5f || transform.position.x >= 15.5f)
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

			if (health <= 0)
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

		if (tag == "Prawn_1") {
			Main.prawnKillCount [0]++;

            if (Main.prawnKillCount[0] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }

                else if(Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_2") {
			Main.prawnKillCount [1]++;

            if (Main.prawnKillCount[1] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if (Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_3") {
			Main.prawnKillCount [2]++;

            if (Main.prawnKillCount[2] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if(Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_4") {
			Main.prawnKillCount [3]++;

            if (Main.prawnKillCount[3] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if(Plane.maxMovementSpeed && Plane.twinBuff == false)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_5") {
			Main.prawnKillCount [4]++;

            if (Main.prawnKillCount[4] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if (Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_6") {
			Main.prawnKillCount [5]++;

            if (Main.prawnKillCount[5] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if (Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }

		if (tag == "Prawn_7") {
			Main.prawnKillCount [6]++;

            if (Main.prawnKillCount[6] == 6)
            {
                if (!Plane.maxMovementSpeed)
                {
                    GameObject powerUp = Instantiate(buffs[1]);
                    powerUp.transform.position = transform.position;
                }
                else if (Plane.maxMovementSpeed && !Plane.twinBuff)
                {
                    GameObject powerUp = Instantiate(buffs[2]);
                    powerUp.transform.position = transform.position;
                }
            }
        }
	}

	void SetWave()
	{
		if (Main.prawnWaves == PrawnWaves.wave_1)

			gameObject.GetComponent<Animator>().SetTrigger("Prawn_1");

		else if (Main.prawnWaves == PrawnWaves.wave_2)
			gameObject.GetComponent<Animator>().SetTrigger("Prawn_2");
		else if (Main.prawnWaves == PrawnWaves.wave_3)
			gameObject.GetComponent<Animator>().SetTrigger("Prawn_3");
        else if (Main.prawnWaves == PrawnWaves.wave_4)
            gameObject.GetComponent<Animator>().SetTrigger("Prawn_4");
        else  
            gameObject.GetComponent<Animator>().SetTrigger("Prawn_5");
    }
}
