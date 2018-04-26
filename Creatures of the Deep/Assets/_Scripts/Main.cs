using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static ShrimpWaves shrimpWaves;
	public static PrawnWaves prawnWaves;

    public static bool dead;

    public static GUIText scoreGT;

    // [0] = Shrimp_Wave_1_1
    // [1] = Shrimp_Wave_1_2
    // [2] = Shrimp_Wave_1_3
	// [3] = Prawn_Wave_1_1
	// [4] = Prawn_Wave_1_2
	// [5] = Prawn_Wave_1_3
    public static int[] enemyWaves = new int[10];
    // Add special of each enemy that drops the buff.

    // [0] = Shrimp
    // [1] = Shrimp Last
    // [2] = Prawn
    // [3] = Prawn Last
    // [4] = Pacu
    public GameObject[] enemies = new GameObject[5];

    // Audio
    public AudioSource[] sounds = new AudioSource[6];

    void Awake()
    {
        Cursor.visible = false;
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        enemyWaves[0] = 0;
        enemyWaves[1] = 0;
        enemyWaves[2] = 0;
        enemyWaves[3] = 0;
        enemyWaves[4] = 0;

        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the GUIText Component of that GameObject
        scoreGT = scoreGO.GetComponent<GUIText>();
        scoreGT.text = "0";

        sounds[0].Play();
        StartCoroutine(Shrimp_1_1());
    }

    IEnumerator RestartGame()
    {
        dead = false;
        sounds[0].Stop();
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel(Application.loadedLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        ///////////
        if (dead)
        {
            StartCoroutine(RestartGame());
        }
        else
        {
            dead = false;
        }
        
		//////////SHRIMP_WAVE_1//////////
        if (enemyWaves[0] == 5)
        {
            StopCoroutine(Shrimp_1_1());
            CancelInvoke("ShrimpSpawn_1_1");
            enemyWaves[0]++;
        }
        if (enemyWaves[0] == 6)
        {
            enemyWaves[0]++;
            Invoke("ShrimpSpawn_1_1_Last", 0.5f);
            StartCoroutine(Shrimp_1_2());
        }

        if (enemyWaves[1] == 5)
        {
            StopCoroutine(Shrimp_1_2());
            CancelInvoke("ShrimpSpawn_1_2");
            enemyWaves[1]++;
        }
        if (enemyWaves[1] == 6)
        {
            enemyWaves[1]++;
            Invoke("ShrimpSpawn_1_2_Last", 0.5f);
            StartCoroutine(Shrimp_1_3());
        }

        if (enemyWaves[2] == 5)
        {
            StopCoroutine(Shrimp_1_2());
            CancelInvoke("ShrimpSpawn_1_3");
            enemyWaves[2]++;
        }
        if (enemyWaves[2] == 6)
        {
            enemyWaves[2]++;
            Invoke("ShrimpSpawn_1_3_Last", 0.5f);   
			StartCoroutine (Prawn_1_1 ());
        }
		//////////SHRIMP_WAVE_1//////////

		//////////PRAWN_WAVE_1//////////
		if (enemyWaves[3] == 5)
		{
			StopCoroutine(Prawn_1_1());
			CancelInvoke("PrawnSpawn_1_1");
			enemyWaves[3]++;
		}
		if (enemyWaves[3] == 6)
		{
			enemyWaves[3]++;
			Invoke("PrawnSpawn_1_1_Last", 0.5f);
			StartCoroutine(Prawn_1_2());
		}

		if (enemyWaves[4] == 5)
		{
			StopCoroutine(Prawn_1_2());
			CancelInvoke("PrawnSpawn_1_2");
			enemyWaves[4]++;
		}
		if (enemyWaves[4] == 6)
		{
			enemyWaves[4]++;
			Invoke("PrawnSpawn_1_2_Last", 0.5f);
			StartCoroutine(Prawn_1_3());
		}

		if (enemyWaves[5] == 5)
		{
			StopCoroutine(Prawn_1_3());
			CancelInvoke("PrawnSpawn_1_3");
			enemyWaves[5]++;
		}
		if (enemyWaves[5] == 6)
		{
			enemyWaves[5]++;
			Invoke("PrawnSpawn_1_3_Last", 0.5f);            
		}
		//////////PRAWN_WAVE_1//////////


    }

    //////////SHRIMP_WAVE_1//////////
    IEnumerator Shrimp_1_1()
    {
        // Increase this later to 3
        yield return new WaitForSeconds(1);
        shrimpWaves = ShrimpWaves.wave_1;
        InvokeRepeating("ShrimpSpawn_1_1", 1, 0.5f);
    }

    IEnumerator Shrimp_1_2()
    {
        // Increase this later to 3
        yield return new WaitForSeconds(2);
		shrimpWaves = ShrimpWaves.wave_2;
        //Shrimp.animTwo = true;
        //Shrimp_Last.animTwo = true;
        InvokeRepeating("ShrimpSpawn_1_2", 1, 0.5f);
    }

    IEnumerator Shrimp_1_3()
    {
        // Increase this later to 3
        yield return new WaitForSeconds(2);
		shrimpWaves = ShrimpWaves.wave_3;
        //Shrimp.animThree = true;
        //Shrimp_Last.animThree = true;
        InvokeRepeating("ShrimpSpawn_1_3", 1, 0.5f);
    }

    void ShrimpSpawn_1_1()
    {
        Instantiate(enemies[0], new Vector3(14, 5, 0), Quaternion.identity);
        enemyWaves[0]++;
    }
    void ShrimpSpawn_1_1_Last()
    {
        Instantiate(enemies[1], new Vector3(14, 5, 0), Quaternion.identity);
        //enemyWaves[0]++;
        print("Last One");
    }

    void ShrimpSpawn_1_2()
    {
        Instantiate(enemies[0], new Vector3(14, 5, 0), Quaternion.identity);
        enemyWaves[1]++;
    }

    void ShrimpSpawn_1_2_Last()
    {
        Instantiate(enemies[1], new Vector3(14, 5, 0), Quaternion.identity);
        //enemyWaves[1]++;
        print("Last One");
    }

    void ShrimpSpawn_1_3()
    {
        Instantiate(enemies[0], new Vector3(14, 5, 0), Quaternion.identity);
        enemyWaves[2]++;
    }

    void ShrimpSpawn_1_3_Last()
    {
        Instantiate(enemies[1], new Vector3(14, 5, 0), Quaternion.identity);
        //enemyWaves[2]++;
        print("Last One");
    }
    //////////SHRIMP_WAVE_1//////////

    //////////PRAWNS_WAVE_2//////////
	IEnumerator Prawn_1_1()
	{
		// Increase this later to 3
		yield return new WaitForSeconds(5);
		prawnWaves = PrawnWaves.wave_1;
		InvokeRepeating("PrawnSpawn_1_1", 1, 0.5f);
	}

	IEnumerator Prawn_1_2()
	{
		// Increase this later to 3
		yield return new WaitForSeconds(1);
		prawnWaves = PrawnWaves.wave_2;
		InvokeRepeating("PrawnSpawn_1_2", 1, 0.5f);
	}

	IEnumerator Prawn_1_3()
	{
		// Increase this later to 3
		yield return new WaitForSeconds(1);
		prawnWaves = PrawnWaves.wave_3;
		InvokeRepeating("PrawnSpawn_1_3", 1, 0.5f);
	}

	void PrawnSpawn_1_1()
    {
        Instantiate(enemies[2], new Vector3(-12, 9, 0), Quaternion.identity);
        enemyWaves[3]++;
    }

	void PrawnSpawn_1_1_Last()
	{
		Instantiate(enemies[3], new Vector3(-12, 9, 0), Quaternion.identity);
		enemyWaves[3]++;
		print("Last One");
	}

	void PrawnSpawn_1_2()
	{
		Instantiate(enemies[2], new Vector3(14, -5, 0), Quaternion.identity);
		enemyWaves[4]++;
	}
	void PrawnSpawn_1_2_Last()
	{
		Instantiate(enemies[3], new Vector3(14, 5, 0), Quaternion.identity);
		enemyWaves[4]++;
		print("Last One");
	}

	void PrawnSpawn_1_3()
	{
		Instantiate(enemies[2], new Vector3(14, -5, 0), Quaternion.identity);
		enemyWaves[5]++;
	}

	void PrawnSpawn_1_3_Last()
	{
		Instantiate(enemies[3], new Vector3(14, 5, 0), Quaternion.identity);
		enemyWaves[5]++;
		print("Last One");
	}
    //////////PRAWNS_WAVE_2//////////

    
	/*IEnumerator ThirdWave()
    {
        yield return new WaitForSeconds(3);
        InvokeRepeating("EnemySpawn3", 1, 1);
    }

    void EnemySpawn3()
    {
        Instantiate(enemies[2], new Vector3(15, 5, 0), Quaternion.identity);
        enemyWaves[2]++;
    }

    IEnumerator FourthWave()
    {
        yield return new WaitForSeconds(2);
        InvokeRepeating("EnemySpawn4", 1, 1);
    }

    void EnemySpawn4()
    {
        Instantiate(enemies[2], new Vector3(15, -5, 0), Quaternion.identity);
        enemyWaves[3]++;
    }

    IEnumerator Boss()
    {
        yield return new WaitForSeconds(5);
        Instantiate(enemies[4], new Vector3(15, 3, 0), Quaternion.identity);
    }*/






}
