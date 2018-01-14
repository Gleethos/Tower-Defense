using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stat : MonoBehaviour {
	public int Health ;

	// Use this for initialization
	void Start () {
		if(Health == 0)
		Health = 3;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.tag == ("Bullet")) {
			Health--;
			Debug.Log ("Health:" + Health);
			if (Health <= 0) {
				Destroy (this.gameObject); 
			}
		}
			
		if(collider.gameObject.tag == ("Granate")) {
			Health-=1;
			Debug.Log ("Health:" + Health);
			if (Health <= 0) {
				Destroy (this.gameObject); 
			}
		}

		if(collider.gameObject.tag == ("Stampfi")) {
			Health--;
			Debug.Log ("Health:" + Health);
			if (Health <= 0) {
				Destroy (this.gameObject); 
			}
		}

		if(collider.gameObject.tag == ("granata_explosiv")) {
			Health-=3;
			Debug.Log ("Health:" + Health);
			if (Health <= 0) {
				Destroy (this.gameObject); 
			}
		}




	}


}
