using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiate : MonoBehaviour
{
    public GameObject[] rocks;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("EjectRocks", 1f, 1f);
    }

    // Update is called once per frame
    void EjectRocks()
    {
        Vector3 newPos = new Vector3(33, -11f, 50);
        GameObject rockInstance = Instantiate(rocks[Random.Range(0, rocks.Length)], newPos, Quaternion.identity);
        rockInstance.transform.position = newPos;
    }
}
