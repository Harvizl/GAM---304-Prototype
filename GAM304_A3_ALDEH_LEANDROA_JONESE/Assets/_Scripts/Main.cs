using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static bool dead;
    public static GUIText scoreGT;

    public static PrawnWaves prawnWaves;
    public static ShrimpWaves shrimpWaves;

    
    public int[] prawnWaveCount = new int[7];
    public int[] shrimpWaveCount = new int[6];

    public static int pacuCount;
    public static int jellyFishCount;
    public static int[] prawnKillCount = new int[7];
    public static int[] shrimpKillCount = new int[6];

    // [0] = Shrimp
    // [1] = Prawn
    // [2] = Jelly Fish
    // [3] = Pacu
    public GameObject[] enemies = new GameObject[4];

    // Audio
    //public AudioSource[] sounds = new AudioSource[6];
    public AudioSource bgm;

    void Awake()
    {
        Cursor.visible = false;
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        /////////////////////////////////
        prawnKillCount[0] = 0;
        prawnKillCount[1] = 0;
        prawnKillCount[2] = 0;
        prawnKillCount[3] = 0;
        prawnKillCount[4] = 0;
        prawnKillCount[5] = 0;
        prawnKillCount[6] = 0;
        /////////////////////////////////
        shrimpKillCount[0] = 0;
        shrimpKillCount[1] = 0;
        shrimpKillCount[2] = 0;
        shrimpKillCount[3] = 0;
        shrimpKillCount[4] = 0;
        shrimpKillCount[5] = 0;
        /////////////////////////////////
        /////////////////////////////////
        /////////////////////////////////
        pacuCount = 0;
        jellyFishCount = 0;
        /////////////////////////////////
        prawnWaveCount[0] = 0;
        prawnWaveCount[1] = 0;
        prawnWaveCount[2] = 0;
        prawnWaveCount[3] = 0;
        prawnWaveCount[4] = 0;
        prawnWaveCount[5] = 0;
        prawnWaveCount[6] = 0;
        /////////////////////////////////
        shrimpWaveCount[0] = 0;
        shrimpWaveCount[1] = 0;
        shrimpWaveCount[2] = 0;
        shrimpWaveCount[3] = 0;
        shrimpWaveCount[4] = 0;
        shrimpWaveCount[5] = 0;

        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the GUIText Component of that GameObject
        scoreGT = scoreGO.GetComponent<GUIText>();
        scoreGT.text = "0";

        //sounds[0].Play();
        bgm.Play();
        StartCoroutine(Shrimp_1());
    }

    IEnumerator RestartGame()
    {
        dead = false;
        //sounds[0].Stop();
        bgm.Stop();
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
        /////////////////////////////////
        if (dead)
        {
            StartCoroutine(RestartGame());
        }
        else
        {
            dead = false;
        }

        //////////SHRIMP_WAVE_1//////////
        if (shrimpWaveCount[0] == 6)
        {
            shrimpWaveCount[0]++;
            StopCoroutine(Shrimp_1());
            CancelInvoke("ShrimpSpawn_1");
            StartCoroutine(Shrimp_2());
        }

        if (shrimpWaveCount[1] == 6)
        {
            shrimpWaveCount[1]++;
            StopCoroutine(Shrimp_2());
            CancelInvoke("ShrimpSpawn_2");
            StartCoroutine(Shrimp_3());
        }

        if (shrimpWaveCount[2] == 6)
        {
            shrimpWaveCount[2]++;
            StopCoroutine(Shrimp_2());
            CancelInvoke("ShrimpSpawn_3");
            StartCoroutine(Prawn_1());
        }
        //////////SHRIMP_WAVE_1//////////        
        /////////////////////////////////
        //////////PRAWN_WAVE_2//////////
        if (prawnWaveCount[0] == 6)
        {
            prawnWaveCount[0]++;
            StopCoroutine(Prawn_1());
            CancelInvoke("PrawnSpawn_1");
            StartCoroutine(Prawn_2());
        }

        if (prawnWaveCount [1] == 6)
        {
            prawnWaveCount[1]++;
            StopCoroutine(Prawn_2());
            CancelInvoke("PrawnSpawn_2");
            StartCoroutine(Prawn_3());
        }

        if (prawnWaveCount[2] == 6)
        {
            prawnWaveCount[2]++;
            StopCoroutine(Prawn_3());
            CancelInvoke("PrawnSpawn_3");
            StartCoroutine(Prawn_4());
        }
        //////////PRAWN_WAVE_2//////////
        /////////////////////////////////
        //////////PRAWN_WAVE_3//////////
        if (prawnWaveCount[3] == 6)
        {
            prawnWaveCount[3]++;
            StopCoroutine(Prawn_4());
            CancelInvoke("PrawnSpawn_4");
            StartCoroutine(Prawn_5());
        }

        if (prawnWaveCount[4] == 6)
        {
            prawnWaveCount[4]++;
            StopCoroutine(Prawn_5());
            CancelInvoke("PrawnSpawn_5");
            StartCoroutine(JellyFish());
            StartCoroutine(Shrimp_4());
        }
        //////////PRAWN_WAVE_3//////////
        /////////////////////////////////
        //////////SHRIMP_PRAWN_JELLYFISH_WAVE_4//////////
        if (shrimpWaveCount[3] == 6)
        {
            shrimpWaveCount[3]++;            
            StopCoroutine(Shrimp_4());
            CancelInvoke("ShrimpSpawn_4");
            StartCoroutine(Prawn_6());
            StartCoroutine(Shrimp_5());
            
        }

        if (shrimpWaveCount[4] == 6)
        {
            shrimpWaveCount[4]++;
            StopCoroutine(Prawn_6());
            StopCoroutine(Shrimp_5());
            CancelInvoke("PrawnSpawn_6");
            CancelInvoke("ShrimpSpawn_5");
            StartCoroutine(JellyFish());
            StartCoroutine(Prawn_7());
            StartCoroutine(Shrimp_6());
        }

        if (shrimpWaveCount[5] == 6)
        {
            shrimpWaveCount[5]++;
            StopCoroutine(Prawn_7());
            StopCoroutine(Shrimp_6());
            CancelInvoke("PrawnSpawn_7");
            CancelInvoke("ShrimpSpawn_6");
            StartCoroutine(Pacu());
        }
        //////////SHRIMP_PRAWN_JELLYFISH_WAVE_4//////////
        /////////////////////////////////
        //////////PACU_WAVE_5//////////
        if (pacuCount == 1)
        {
            pacuCount++;
            StopCoroutine(Pacu());
        }
        //////////PACU_WAVE_5//////////
    }

    //////////SHRIMP_SPAWNING//////////
    IEnumerator Shrimp_1()
    {
        // Increase this later to 3
        yield return new WaitForSeconds(1);
        shrimpWaves = ShrimpWaves.wave_1;
        InvokeRepeating("ShrimpSpawn_1", 1, 0.5f);
    }
    IEnumerator Shrimp_2()
    {
        yield return new WaitForSeconds(2);
        shrimpWaves = ShrimpWaves.wave_2;
        InvokeRepeating("ShrimpSpawn_2", 1, 0.5f);
    }
    IEnumerator Shrimp_3()
    {
        yield return new WaitForSeconds(2);
        shrimpWaves = ShrimpWaves.wave_3;
        InvokeRepeating("ShrimpSpawn_3", 1, 0.5f);
    }
    IEnumerator Shrimp_4()
    {
        yield return new WaitForSeconds(2);
        shrimpWaves = ShrimpWaves.wave_1;
        InvokeRepeating("ShrimpSpawn_4", 1, 0.5f);
    }
    IEnumerator Shrimp_5()
    {
        yield return new WaitForSeconds(2);
        shrimpWaves = ShrimpWaves.wave_2;
        InvokeRepeating("ShrimpSpawn_5", 1, 0.5f);
    }
    IEnumerator Shrimp_6()
    {
        yield return new WaitForSeconds(2);
        shrimpWaves = ShrimpWaves.wave_3;
        InvokeRepeating("ShrimpSpawn_6", 1, 0.5f);
    }
    /////////////////////////////////
    void ShrimpSpawn_1()
    {
        GameObject shrimp1 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp1.tag = "Shrimp_1";
        shrimpWaveCount[0]++;
    }
    void ShrimpSpawn_2()
    {
        GameObject shrimp2 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp2.tag = "Shrimp_2";
        shrimpWaveCount[1]++;
    }
    void ShrimpSpawn_3()
    {
        GameObject shrimp3 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp3.tag = "Shrimp_3";
        shrimpWaveCount[2]++;
    }
    void ShrimpSpawn_4()
    {
        GameObject shrimp4 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp4.tag = "Shrimp_4";
        shrimpWaveCount[3]++;
    }
    void ShrimpSpawn_5()
    {
        GameObject shrimp5 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp5.tag = "Shrimp_5";
        shrimpWaveCount[4]++;
    }
    void ShrimpSpawn_6()
    {
        GameObject shrimp6 = Instantiate(enemies[0], new Vector3(15, 5, 0), Quaternion.identity);
        shrimp6.tag = "Shrimp_6";
        shrimpWaveCount[5]++;
    }
    //////////SHRIMP_SPAWNING//////////
    /////////////////////////////////
    //////////PRAWNS_SPAWNING//////////
    IEnumerator Prawn_1()
    {
        yield return new WaitForSeconds(3);
        prawnWaves = PrawnWaves.wave_1;
        InvokeRepeating("PrawnSpawn_1", 1, 0.5f);
    }
    IEnumerator Prawn_2()
    {
        yield return new WaitForSeconds(1);
        prawnWaves = PrawnWaves.wave_2;
        InvokeRepeating("PrawnSpawn_2", 1, 0.5f);
    }
    IEnumerator Prawn_3()
    {
        yield return new WaitForSeconds(1);
        prawnWaves = PrawnWaves.wave_3;
        InvokeRepeating("PrawnSpawn_3", 1, 0.5f);
    }
    IEnumerator Prawn_4()
    {
        yield return new WaitForSeconds(5);
        prawnWaves = PrawnWaves.wave_4;
        InvokeRepeating("PrawnSpawn_4", 1, 0.5f);
    }

    IEnumerator Prawn_5()
    {
        yield return new WaitForSeconds(0);
        prawnWaves = PrawnWaves.wave_5;
        InvokeRepeating("PrawnSpawn_5", 1, 0.5f);
    }
    IEnumerator Prawn_6()
    {
        yield return new WaitForSeconds(0);
        prawnWaves = PrawnWaves.wave_4;
        InvokeRepeating("PrawnSpawn_6", 1, 0.5f);
    }
    IEnumerator Prawn_7()
    {
        yield return new WaitForSeconds(0);
        prawnWaves = PrawnWaves.wave_5;
        InvokeRepeating("PrawnSpawn_7", 1, 0.5f);
    }
    /////////////////////////////////
    void PrawnSpawn_1()
    {
        GameObject prawn1 = Instantiate(enemies[1], new Vector3(-12, 9, 0), Quaternion.identity);
        prawn1.tag = "Prawn_1";
        prawnWaveCount[0]++;
    }
    void PrawnSpawn_2()
    {
        GameObject prawn2 = Instantiate(enemies[1], new Vector3(15, 0, 0), Quaternion.identity);
        prawn2.tag = "Prawn_2";
        prawnWaveCount[1]++;
    }
    void PrawnSpawn_3()
    {
        GameObject prawn3 = Instantiate(enemies[1], new Vector3(-12, -9, 0), Quaternion.identity);
        prawn3.tag = "Prawn_3";
        prawnWaveCount[2]++;
    }
    void PrawnSpawn_4()
    {
        GameObject prawn4 = Instantiate(enemies[1], new Vector3(15, 10, 0), Quaternion.identity);
        prawn4.tag = "Prawn_4";
        prawnWaveCount[3]++;
    }
    void PrawnSpawn_5()
    {
        GameObject prawn5 = Instantiate(enemies[1], new Vector3(15, -10, 0), Quaternion.identity);
        prawn5.tag = "Prawn_5";
        prawnWaveCount[4]++;
    }
    void PrawnSpawn_6()
    {
        GameObject prawn6 = Instantiate(enemies[1], new Vector3(15, -10, 0), Quaternion.identity);
        prawn6.tag = "Prawn_6";
        prawnWaveCount[5]++;
    }
    void PrawnSpawn_7()
    {
        GameObject prawn7 = Instantiate(enemies[1], new Vector3(15, -10, 0), Quaternion.identity);
        prawn7.tag = "Prawn_7";
        prawnWaveCount[6]++;
    }
    //////////PRAWNS_SPAWNING//////////

    //////////JELLYFISH_SPAWNING//////////
    IEnumerator JellyFish()
    {
        yield return new WaitForSeconds(2);
        InvokeRepeating("SpawnJellyFish", 1, 5);
        InvokeRepeating("SpawnJellyFish2", 2, 5);
        InvokeRepeating("SpawnJellyFish3", 4, 5);
        InvokeRepeating("SpawnJellyFish4", 2, 5);
        InvokeRepeating("SpawnJellyFish5", 3, 5);
        yield return new WaitForSeconds(20);
        CancelInvoke("SpawnJellyFish");
        CancelInvoke("SpawnJellyFish2");
        CancelInvoke("SpawnJellyFish3");
        CancelInvoke("SpawnJellyFish4");
        CancelInvoke("SpawnJellyFish5");
    }
    /////////////////////////////////
    void SpawnJellyFish()
    {
        GameObject jFish = Instantiate(enemies[2], new Vector3(1.5f, -9, 0), Quaternion.identity);
        jFish.GetComponent<Animator>().SetTrigger("JellyFish");
    }
    void SpawnJellyFish2()
    {
        GameObject jFish2 = Instantiate(enemies[2], new Vector3(-6, -9, 0), Quaternion.identity);
        jFish2.GetComponent<Animator>().SetTrigger("JellyFish2");
    }
    void SpawnJellyFish3()
    {
        GameObject jFish3 = Instantiate(enemies[2], new Vector3(8,-9,0), Quaternion.identity);
        jFish3.GetComponent<Animator>().SetTrigger("JellyFish3");
    }
    void SpawnJellyFish4()
    {
        GameObject jFish4 = Instantiate(enemies[2], new Vector3(2, -9, 0), Quaternion.identity);
        jFish4.GetComponent<Animator>().SetTrigger("JellyFish4");
    }
    void SpawnJellyFish5()
    {
        GameObject jFish5 = Instantiate(enemies[2], new Vector3(4, -9, 0), Quaternion.identity);
        jFish5.GetComponent<Animator>().SetTrigger("JellyFish5");
    }
    //////////JELLYFISH_SPAWNING//////////
    /////////////////////////////////
    //////////PACU_SPAWNING//////////
    IEnumerator Pacu()
    {
        yield return new WaitForSeconds(12);
        SpawnPacu();
    }
    /////////////////////////////////
    void SpawnPacu()
    {
        GameObject pacu = Instantiate(enemies[3], new Vector3(17, 4, 0), Quaternion.identity);
    }
    //////////PACU_SPAWNING//////////
}
