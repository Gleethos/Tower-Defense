using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {


	[SerializeField] 
	private GameObject BaseTexture;


	double Health;

	int x;
	int y;

	// Use this for initialization
	void Start () {x=0; y=0; Health=100;

		GameObject newBase = Instantiate(BaseTexture);
		newBase.transform.position = new Vector3(x, y, -3);

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void damageBase(double damage)
	{Health -= damage;}

	public void modifyBaseHealth(double modification)
	{Health += modification;}




}
