using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Behavior_PewPew : MonoBehaviour {

	public int visionRadius;
	public float attackSpeed;
	//public int dmg;
	public float rotateSpeed;
	float time;
	float targetAngle;
	public GameObject bullet; // same as ammo

	List<GameObject> targetInRange;
	GameObject target;


	// Use this for initialization
	void Start () {

		targetInRange = new List<GameObject> ();

		//read in hitbox of turrets
		CircleCollider2D collider = GetComponent <CircleCollider2D> ();
		collider.radius = visionRadius;



	}
	
	// Update is called once per frame
	void Update () {

		//time correction
		time += Time.deltaTime*1;

		//Debug.Log (time);

		if (targetInRange.Count > 0 && target != null) {
			//rotate to target
			//Degrees of rotation
			float targetAngle = Mathf.Atan2 (
				                    transform.position.y - target.transform.position.y,
				                    transform.position.x - target.transform.position.x
			                    ) * Mathf.Rad2Deg;

			float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, targetAngle, Time.deltaTime * rotateSpeed);

			transform.eulerAngles = new Vector3 (0f, 0f, nextAngle);

		
			if (IsNearTargetAngle (transform.eulerAngles.z, targetAngle, 5f)) {

				// Make yure enought time has passed to fire the bullet
				if (time >= attackSpeed) {

					//Debug.Log ("FIRE!");
					GameObject bulletClone = Instantiate (bullet, transform.position, Quaternion.identity);
					Bullet bulletScript = bulletClone.GetComponent <Bullet> ();
					bulletScript.SetVelocityVectors (
						Mathf.Cos (targetAngle * Mathf.Deg2Rad) * -1f, 
						Mathf.Sin (targetAngle * Mathf.Deg2Rad) * -1f,
						20f);

					time = 0f;

				}
			}
		
		
		} else {
				
			//Startposition
			float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, 0f, Time.deltaTime * rotateSpeed);
			transform.eulerAngles = new Vector3 (0f, 0f, nextAngle);
			
		}


	}

	//correct Aiming
	bool IsNearTargetAngle(float current, float target, float offset){
		//Debug.Log ("Differenz between target and current:" + (target - current));
		//Debug.Log ("Mathf.Abs:" + Mathf.Abs (target - current));

		if ((target - current) <= offset)
			return true;
		return false;
	}

	//add enemies
	void OnTriggerEnter2D(Collider2D collider){

		if (targetInRange.Count == 0) {
			target = collider.gameObject;
		}

		targetInRange.Add (collider.gameObject);

	}

	//delete enemies
	void OnTriggerExit2D(Collider2D collider){

		targetInRange.Remove (collider.gameObject);

		if (targetInRange.Count > 0) {
			target = targetInRange [0];
		} else {
			target = null;

			//targetAngle =  Mathf.Atan2 (0,0) * Mathf.Rad2Deg;
			//float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, 180f, Time.deltaTime * rotateSpeed);




		}

	}

}
