using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Plane : MonoBehaviour
{
    // Health
    public static bool shield;
    public bool canDie;

    // Audio
    public AudioSource[] sounds = new AudioSource[6];
    // Explosions
    public GameObject[] explosions = new GameObject[2];

    // Shooting Cooldown
    public int shot = 1;

    // 1: Player_Bullet
    // 2: Player_Bullet_Ghost
    public GameObject[] playerBullet = new GameObject[2];

    // Power Ups
    //int speedBuffCount = 0;

    // [0] = shootingSpeedBuffCount
    // [1] = movementSpeedBuffCount
    public static int[] buffCounts = new int[2];
    public bool twinBuff;

    public GameObject[] powerUpBuffs = new GameObject[4];

    // [0]: Twin Shot
    // [1]: Movementspeed Buff
    // [2]: Shield
    GameObject[] powerUpGOs = new GameObject[3];
    public static int buffCount = 0;

    // Use this for initialization
    void Start()
    {
        // Start with Shield
        shield = true;
        canDie = false;

        // Shoot Speed Buff
        twinBuff = false;

        // Shield
        powerUpGOs[2] = GameObject.Find("Shield");

        // Buff Counts
        buffCounts[0] = 0;
        buffCounts[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
			{
			print ("Weeee");
			GetComponent<Rigidbody>().AddForce(Vector3.right * 200 * Time.deltaTime);
			}
		else
		{
			// Movement
			Move();
		}

        // Shield health
        if (shield)
        {
            powerUpGOs[2].SetActive(true);
        }
        else
        {
            powerUpGOs[2].SetActive(false);
        }        

        if (Input.GetAxis("Jump") == 1 && shot > 0)
        {
            StartCoroutine(Shoot());

            if (twinBuff)
            {
                TwinBuff();
            }
        }
    }

    //////////MOVEMENT//////////
    void Move()
    {
        // pull information from the input class
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        if (buffCounts[1] == 0)
        {
            // Change transform.position based on the axes
            Vector3 pos = transform.position;
            pos.y += yAxis * 6f * Time.deltaTime;
            pos.x += xAxis * 6f * Time.deltaTime;
            transform.position = pos;
        }
        else if (buffCounts[1] == 1)
        {
            Vector3 pos = transform.position;
            pos.y += yAxis * 8f * Time.deltaTime;
            pos.x += xAxis * 8f * Time.deltaTime;
            transform.position = pos;
        }
        else if (buffCounts[1] == 2)
        {
            Vector3 pos = transform.position;
            pos.y += yAxis * 10f * Time.deltaTime;
            pos.x += xAxis * 10f * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y += yAxis * 15f * Time.deltaTime;
            pos.x += xAxis * 15f * Time.deltaTime;
            transform.position = pos;
        }
        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * 30, 0, xAxis * -12);

		// Restricts players movement
		Vector3 currentPosition = transform.position;
		float clampedX = Mathf.Clamp(currentPosition.x, -11f, 11f);
		float clampedY = Mathf.Clamp(currentPosition.y, -7f, 7f);

		if (!Mathf.Approximately(clampedX, currentPosition.x))
		{
			currentPosition.x = clampedX;
			transform.position = currentPosition;
		}
		if (!Mathf.Approximately(clampedY, currentPosition.y))
		{
			currentPosition.y = clampedY;
			transform.position = currentPosition;
		}
    }
    //////////MOVEMENT//////////

    //////////SHOOTING//////////
    void TwinBuff()
    {
        Transform bulletTransform = playerBullet[0].GetComponent<Transform>();
		Vector3 tempPos = transform.position;
        tempPos.y = tempPos.y + -0.1f;
        tempPos.x = tempPos.x + 2f;
        bulletTransform.position = tempPos;

        // Calls Bullet prefab at offset location
        GameObject twinShot = Instantiate(playerBullet[0], bulletTransform.position, Quaternion.identity);
        // Obtain Bullet prefab's Rigidbody
        Rigidbody twinShotRB = twinShot.GetComponent<Rigidbody>();
        // Shoots Bullet to the right
        twinShotRB.velocity += 35f * Vector3.right;
    }

    IEnumerator Shoot()
    {
        Transform bulletTransform = playerBullet[0].GetComponent<Transform>();
		Vector3 tempPos = transform.position;
        tempPos.y = tempPos.y - 0.4f;
        tempPos.x = tempPos.x + 2;
        bulletTransform.position = tempPos;

        // Calls Bullet prefab at Plane's current location
        GameObject projectileInstance = Instantiate(playerBullet[0], bulletTransform.position, Quaternion.identity);
        // Obtain Bullet prefab's Rigidbody
        Rigidbody projectileRb = projectileInstance.GetComponent<Rigidbody>();
        // Shoots Bullet to the right
        projectileRb.velocity += 35f * Vector3.right;
        // Subtracts 1 int to the 'shot' counter
        shot--;
        sounds[1].Play();

        if (buffCounts[0] == 0)
        {
            yield return new WaitForSeconds(.5f);
            shot++;
        }
        else if (buffCounts[0] == 1)
        {
            sounds[1].Play();
            yield return new WaitForSeconds(.4f);
            shot++;
        }
        else if (buffCounts[0] == 2)
        {
            sounds[1].Play();
            yield return new WaitForSeconds(.3f);
            shot++;
        }
        else
        {
            sounds[1].Play();
            yield return new WaitForSeconds(.2f);
            shot++;
        }
    }
    //////////SHOOTING//////////

    void OnTriggerEnter(Collider other)
    {
        // Shrimps
		if (other.tag.Contains ("Shrimp"))
        {
			other.SendMessage("Death");
			Instantiate(explosions[1], other.transform.position, Quaternion.identity);
            sounds[3].Play();
            shield = false;

            if (shield == false && canDie == true)
            {
                sounds[0].Play();
                Destroy(gameObject);
                Instantiate(explosions[0], transform.position, Quaternion.identity);
            }
            else
            {
                canDie = true;
                sounds[5].Play();
            }

            int score = int.Parse(Main.scoreGT.text);
            score += 100;
            Main.scoreGT.text = score.ToString();
        }

		// Prawns
		if (other.tag.Contains ("Prawn"))
		{
			other.SendMessage("Death");
			Instantiate(explosions[1], other.transform.position, Quaternion.identity);
			sounds[3].Play();
			shield = false;

			if (shield == false && canDie == true)
			{
				sounds[0].Play();
				Destroy(gameObject);
				Instantiate(explosions[0], transform.position, Quaternion.identity);
			}
			else
			{
				canDie = true;
				sounds[5].Play();
			}

			int score = int.Parse(Main.scoreGT.text);
			score += 100;
			Main.scoreGT.text = score.ToString();
		}

		//Jelly Fish
		if (other.tag.Contains ("Jelly"))
		{
			other.SendMessage("Death");
			Instantiate(explosions[1], other.transform.position, Quaternion.identity);
			sounds[3].Play();
			shield = false;

			if (shield == false && canDie == true)
			{
				sounds[0].Play();
				Destroy(gameObject);
				Instantiate(explosions[0], transform.position, Quaternion.identity);
			}
			else
			{
				canDie = true;
				sounds[5].Play();
			}

			int score = int.Parse(Main.scoreGT.text);
			score += 100;
			Main.scoreGT.text = score.ToString();
		}

        // Pacu Fish
        if (other.tag == "Pacu")
        {
            shield = false;
            Boss.health--;
            sounds[4].Play();

            if (shield == false && canDie == true)
            {
                sounds[0].Play();
                Destroy(gameObject);
                Instantiate(explosions[0], transform.position, Quaternion.identity);
            }
            else
            {
                canDie = true;
                sounds[5].Play();
            }
        }

        // Enemy Projectiles
        if (other.tag == "Enemy_Bullet")
        {
            shield = false;
            Destroy(other.gameObject);

            if (shield == false && canDie == true)
            {
                sounds[0].Play();
                Destroy(gameObject);
                Instantiate(explosions[0], transform.position, Quaternion.identity);
            }
            else
            {
                canDie = true;
                sounds[5].Play();
            }
        }

        // Twin Shot Power Up
        if (other.tag == "Twin Shot")
        {
            Destroy(other.gameObject);
            twinBuff = true;
            sounds[2].Play();

            int score = int.Parse(Main.scoreGT.text);
            score += 50;
            Main.scoreGT.text = score.ToString();
        }

        // Movement Speed Power Up
        if (other.tag == "Movement Speed Buff")
        {
            Destroy(other.gameObject);
            buffCounts[1]++;
            sounds[2].Play();

            int score = int.Parse(Main.scoreGT.text);
            score += 50;
            Main.scoreGT.text = score.ToString();
        }

        // Shoot Speed Power Up
        if (other.tag == "Shoot Speed Buff")
        {
            Destroy(other.gameObject);
            buffCounts[0]++;
            sounds[2].Play();

            int score = int.Parse(Main.scoreGT.text);
            score += 50;
            Main.scoreGT.text = score.ToString();
        }

        // Shield Power Up
        if (other.tag == "Shield Buff")
        {
            Destroy(other.gameObject);
            shield = true;
            canDie = false;
            sounds[2].Play();

            int score = int.Parse(Main.scoreGT.text);
            score += 50;
            Main.scoreGT.text = score.ToString();
        }
    }

    // On Death
    void OnDestroy()
    {
        Main.dead = true;
    }
}
