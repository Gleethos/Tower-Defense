using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stampfi: MonoBehaviour {
	public float desapwnTime = 0.5f;
	//int Health = FindObjectOfType; 



	// Use this for initialization
	void Start () {

	}
		



	// Update is called once per frame
	void Update () {

		desapwnTime -= 1 * Time.deltaTime;

		if (desapwnTime <= 0) {
			Destroy (gameObject);
		}




	}





}