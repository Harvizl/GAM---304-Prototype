using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	public float moveSpeed = 10f;
	public float minX = -60f;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		if (gameObject.transform.position.x < minX) 
		{
			Destroy (gameObject);
		}

	}

}
