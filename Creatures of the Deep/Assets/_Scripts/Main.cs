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

	public static int[] shrimpKillCount = new int[5];
	public static int[] prawnKillCount = new int[8];
    public static int jellyFishCount;

    public static GUIText scoreGT;

    // [0] = Shrimp_Wave_1_1
    // [1] = Shrimp_Wave_1_2
    // [2] = Shrimp_Wave_1_3
    // [3] = Prawn_Wave_1_1
    // [4] = Prawn_Wave_1_2
    // [5] = Prawn_Wave_1_3
    // [6] = Prawn_Wave_1_4
    // [7] = Prawn_Wave_1_5
    public int[] enemyWaves = new int[10];
    // Add special of each enemy that drops the buff.

    // [0] = Shrimp_1
	// [1] = Shrimp_2
	// [2] = Shrimp_3
	// [3] = Shrimp_4
	// [4] = Shrimp_5
	// [5] = Shrimp_6
	// [6] = Prawn_1
	// [7] = Prawn_2
	// [8] = Prawn_3
	// [9] = Prawn_4
	// [10] = Prawn_5
	// [11] = Prawn_6
	// [12] = Prawn_7
	// [13] = Prawn_8
	// [14] = Pacu
    public GameObject[] enemies = new GameObject[15];

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

		shrimpKillCount [0] = 0;
		shrimpKillCount [1] = 0;
		shrimpKillCount [2] = 0;

        jellyFishCount = 0;

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

        //////////WAVE_1_SHRIMP//////////
		if (enemyWaves[0] == 6)
		{
			enemyWaves[0]++;
			StopCoroutine(Shrimp_1_1());
			CancelInvoke("ShrimpSpawn_1_1");
			StartCoroutine(Shrimp_1_2());
		}

        if (enemyWaves[1] == 6)
        {
			enemyWaves[1]++;
			StopCoroutine(Shrimp_1_2());
            CancelInvoke("ShrimpSpawn_1_2");
            StartCoroutine(Shrimp_1_3());
        }

        if (enemyWaves[2] == 6)
        {
			enemyWaves[2]++;
            StopCoroutine(Shrimp_1_2());
            CancelInvoke("ShrimpSpawn_1_3");
			StartCoroutine (Prawn_1_1 ());
        }
        //////////WAVE_1_SHRIMP//////////

        //////////WAVE_1_PRAWN//////////
        if (enemyWaves[3] == 6)
		{
			enemyWaves[3]++;
			StopCoroutine(Prawn_1_1());
			CancelInvoke("PrawnSpawn_1_1");
			StartCoroutine(Prawn_1_2());
		}

		if (enemyWaves[4] == 6)
		{
			enemyWaves[4]++;
			StopCoroutine(Prawn_1_2());
			CancelInvoke("PrawnSpawn_1_2");
			StartCoroutine(Prawn_1_3());
		}

		if (enemyWaves[5] == 6)
		{
			enemyWaves[5]++;
			StopCoroutine(Prawn_1_3());
			CancelInvoke("PrawnSpawn_1_3");
			StartCoroutine(Prawn_1_4());
		}
        //////////WAVE_1_PRAWN//////////

        //////////WAVE_2_PRAWN//////////
        if (enemyWaves[6] == 6)
        {
			enemyWaves[6]++;
            StopCoroutine(Prawn_1_4());            
            CancelInvoke("PrawnSpawn_1_4");
			StartCoroutine(Prawn_1_5());
        }

        if (enemyWaves[7] == 6)
        {
			enemyWaves[7]++;
            StopCoroutine(Prawn_1_5());
            CancelInvoke("PrawnSpawn_1_5");
            //StartCoroutine - jellyfish,shrimps,prawns
        }
        //////////WAVE_2_PRAWN//////////
    }

    //////////WAVE_1_SHRIMP//////////
    IEnumerator Shrimp_1_1()
    {
        // Increase this later to 3
        yield return new WaitForSeconds(1);
        shrimpWaves = ShrimpWaves.wave_1;
        InvokeRepeating("ShrimpSpawn_1_1", 1, 0.5f);
    }

    IEnumerator Shrimp_1_2()
    {
        yield return new WaitForSeconds(2);
		shrimpWaves = ShrimpWaves.wave_2;
        InvokeRepeating("ShrimpSpawn_1_2", 1, 0.5f);
    }

    IEnumerator Shrimp_1_3()
    {
        yield return new WaitForSeconds(2);
		shrimpWaves = ShrimpWaves.wave_3;
        InvokeRepeating("ShrimpSpawn_1_3", 1, 0.5f);
    }

    void ShrimpSpawn_1_1()
    {
        Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        enemyWaves[0]++;
    }

    void ShrimpSpawn_1_2()
    {
        Instantiate(enemies[1], new Vector3(15, 5, 0), Quaternion.identity);
        enemyWaves[1]++;
    }

    void ShrimpSpawn_1_3()
    {
        Instantiate(enemies[2], new Vector3(15, 5, 0), Quaternion.identity);
        enemyWaves[2]++;
    }
    //////////WAVE_1_SHRIMP//////////

    //////////WAVE_2_PRAWNS//////////
    IEnumerator Prawn_1_1()
	{
		yield return new WaitForSeconds(3);
		prawnWaves = PrawnWaves.wave_1;
		InvokeRepeating("PrawnSpawn_1_1", 1, 0.5f);
	}

	IEnumerator Prawn_1_2()
	{
		yield return new WaitForSeconds(1);
		prawnWaves = PrawnWaves.wave_2;
		InvokeRepeating("PrawnSpawn_1_2", 1, 0.5f);
	}

	IEnumerator Prawn_1_3()
	{
		yield return new WaitForSeconds(1);
		prawnWaves = PrawnWaves.wave_3;
		InvokeRepeating("PrawnSpawn_1_3", 1, 0.5f);
	}

	void PrawnSpawn_1_1()
    {
        Instantiate(enemies[6], new Vector3(-12, 9, 0), Quaternion.identity);
        enemyWaves[3]++;
    }

	void PrawnSpawn_1_2()
	{
		Instantiate(enemies[7], new Vector3(15, 0, 0), Quaternion.identity);
		enemyWaves[4]++;
	}

	void PrawnSpawn_1_3()
	{
		Instantiate(enemies[8], new Vector3(-12, -9, 0), Quaternion.identity);
		enemyWaves[5]++;
	}
    //////////WAVE_2_PRAWNS//////////

    //////////WAVE_3_PRAWNS//////////
    IEnumerator Prawn_1_4()
    {
        yield return new WaitForSeconds(5);
        prawnWaves = PrawnWaves.wave_4;
        InvokeRepeating("PrawnSpawn_1_4", 1, 0.5f);
    }

    IEnumerator Prawn_1_5()
    {
        yield return new WaitForSeconds(0);
        prawnWaves = PrawnWaves.wave_5;
        InvokeRepeating("PrawnSpawn_1_5", 1, 0.5f);
    }

    void PrawnSpawn_1_4()
    {
        Instantiate(enemies[9], new Vector3(15, 10, 0), Quaternion.identity);
        enemyWaves[6]++;
    }

    void PrawnSpawn_1_5()
    {
        Instantiate(enemies[10], new Vector3(15, -10, 0), Quaternion.identity);
        enemyWaves[7]++;
    }
	//////////WAVE_3_PRAWNS//////////

	//////////WAVE_4_PRAWNS_&_JELLYFISH//////////


	//////////WAVE_4_PRAWNS_&_JELLYFISH//////////


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
