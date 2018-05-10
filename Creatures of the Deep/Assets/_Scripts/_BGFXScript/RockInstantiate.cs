using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstantiate : MonoBehaviour {
	public GameObject[] rocks;
	public GameObject rockEjector;

	// Use this for initialization
	void Start() 
	{
		InvokeRepeating ("EjectRocks", 1f, 1f);
	}
	
	// Update is called once per frame
	void EjectRocks () 
	{
		GameObject rockInstance = Instantiate (rocks[Random.Range(0,rocks.Length)], rockEjector.transform.position, transform.rotation);
		Vector3 newPos = rockEjector.transform.position;
		rockInstance.transform.position = newPos;
	}
}
