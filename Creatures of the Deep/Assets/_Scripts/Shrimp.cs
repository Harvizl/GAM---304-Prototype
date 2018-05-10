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
	public GameObject powerUpPrefab;

	// Use this for initialization
	void Start ()
	{
		SetWave ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x <= -14 || transform.position.x >= 15.5f) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player_Bullet") {
			health--;
			Destroy (other.gameObject);
		
			if (health == 0) {
				Death ();
			}
		}
	}

	void Death ()
	{
		Destroy (gameObject);

		Instantiate (explosion, transform.position, Quaternion.identity);

		// Parse the text of the scoreGT into an int
		int score = int.Parse (Main.scoreGT.text);
		score += 100;

		// Convert the score back to a string and display it
		Main.scoreGT.text = score.ToString ();

		if (tag == "Shrimp_1") {
			Main.shrimpKillCount [0]++;
		
			if (Main.shrimpKillCount [0] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}

		if (tag == "Shrimp_2") {
			Main.shrimpKillCount [1]++;
		
			if (Main.shrimpKillCount [1] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}

		if (tag == "Shrimp_3") {
			Main.shrimpKillCount [2]++;
		
			if (Main.shrimpKillCount [2] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}

		if (tag == "Shrimp_4") {
			Main.shrimpKillCount [3]++;

			if (Main.shrimpKillCount [3] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}

		if (tag == "Shrimp_5") {
			Main.shrimpKillCount [4]++;

			if (Main.shrimpKillCount [4] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}

		if (tag == "Shrimp_6") {
			Main.shrimpKillCount [5]++;

			if (Main.shrimpKillCount [5] == 6) {
				GameObject powerUp = Instantiate (powerUpPrefab);
				powerUp.transform.position = transform.position;
			}
		}
	}

	void SetWave ()
	{
		if (Main.shrimpWaves == ShrimpWaves.wave_1)
			gameObject.GetComponent<Animator> ().SetTrigger ("Shrimp_1");
		else if (Main.shrimpWaves == ShrimpWaves.wave_2)
			gameObject.GetComponent<Animator> ().SetTrigger ("Shrimp_2");
		else
			gameObject.GetComponent<Animator> ().SetTrigger ("Shrimp_3");
	}
}
