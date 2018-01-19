using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stat_water : MonoBehaviour {
	public int Health ;
	private float regen = 0;
	public int threshold = 15;
	public int healthRegen = 5;


	// Use this for initialization
	void Start () {

		//Just if no value set
		if(Health == 0)
			Health = 20;		
	}

	// Update is called once per frame
	void Update () {
		regen += Time.deltaTime*1;

		if (regen >= 6 && Health <= threshold) {
			Health += healthRegen;
			regen = 0;
		}

		//no life == destroy it
		if (Health <= 0) { 
			GameObject Placement = GameObject.Find ("Placement");
			Turret_Placement turmScript = Placement.GetComponent<Turret_Placement> ();
			turmScript.balance++;
			turmScript.score+=10;
			Destroy (this.gameObject);
		}

	}

	public void OnCollisionEnter2D(Collision2D collider){

		//Ammo check
		if(collider.gameObject.tag == ("Bullet")) {
			Health--;
			//Debug.Log ("Health:" + Health);

		}

		if(collider.gameObject.tag == ("Granate")) {
			Health-=1;
			//Debug.Log ("Health:" + Health);
		}

		if(collider.gameObject.tag == ("Stampfi")) {
			Health-=5;
			//Debug.Log ("Health:" + Health);
		}

		if(collider.gameObject.tag == ("granata_explosiv")) {
			Health-=20;
			//Debug.Log ("Health:" + Health);
		}




	}


}
