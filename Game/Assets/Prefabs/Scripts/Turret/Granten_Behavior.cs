using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granten_Behavior : MonoBehaviour {
	public int visionRadius;
	public float attackSpeed;
	//public int dmg;
	public float rotateSpeed;
	float time = 4;
	float targetAngle;
	//bullet same as ammo
	public GameObject bullet;

	//Array which enemies are in range
	List<GameObject> targetInRange;
	GameObject target;


	// Use this for initialization
	void Start () {

		//start as a new List
		targetInRange = new List<GameObject> ();

		//read in colliders of turret
		CircleCollider2D collider = GetComponent <CircleCollider2D> ();
		collider.radius = visionRadius;



	}

	// Update is called once per frame
	void Update () {

		//time correction
		time += Time.deltaTime*1;

		//Debug.Log (time);

		// what happen, if target is in range
		if (targetInRange.Count > 0 && target != null) {

			//rotate to target
			//Degrees of rotation
			float targetAngle = Mathf.Atan2 (
				transform.position.y - target.transform.position.y,
				transform.position.x - target.transform.position.x
			) * Mathf.Rad2Deg;

			//Aiming
			float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, targetAngle, Time.deltaTime * rotateSpeed);
			transform.eulerAngles = new Vector3 (0f, 0f, nextAngle);

			//Correcting aiming
			if (IsNearTargetAngle (transform.eulerAngles.z, targetAngle, 5f)) {

				// Make yure enought time has passed to fire the bullet
				if (time >= attackSpeed) {

					//Debug.Log ("FIRE!");
					//Initiate bullet script + object
					GameObject bulletClone = Instantiate (bullet, transform.position, Quaternion.identity);
					Granati bulletScript = bulletClone.GetComponent <Granati> ();
					bulletScript.SetVelocityVectors (
						Mathf.Cos (targetAngle * Mathf.Deg2Rad) * -1f, 
						Mathf.Sin (targetAngle * Mathf.Deg2Rad) * -1f,
						10f);

					time = 0f;

				}
			}


		} else {

			//rotate back to the first position
			float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, 0f, Time.deltaTime * rotateSpeed);
			transform.eulerAngles = new Vector3 (0f, 0f, nextAngle);

		}


	}

	bool IsNearTargetAngle(float current, float target, float offset){
		//Debug.Log ("Differenz between target and current:" + (target - current));
		//Debug.Log ("Mathf.Abs:" + Mathf.Abs (target - current));
		//calculate the precision of aiming
		if ((target - current) <= offset)
			return true;
		return false;
	}

	//add enemies to the array
	void OnTriggerEnter2D(Collider2D collider){

		if (targetInRange.Count == 0) {
			target = collider.gameObject;
		}

		targetInRange.Add (collider.gameObject);

	}

	//delete enemies from array
	void OnTriggerExit2D(Collider2D collider){

		targetInRange.Remove (collider.gameObject);

		if (targetInRange.Count > 0) {
			target = targetInRange [0];
		} else {
			//no elemts
			target = null;

			//targetAngle =  Mathf.Atan2 (0,0) * Mathf.Rad2Deg;
			//float nextAngle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, 180f, Time.deltaTime * rotateSpeed);




		}

	}

}
