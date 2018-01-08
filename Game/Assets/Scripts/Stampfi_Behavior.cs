using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stampfi_Behavior : MonoBehaviour {

		public int visionRadius;
		public float attackSpeed;
		public int dmg;
		float time;
		float targetAngle;
		public GameObject bullet;

		List<GameObject> targetInRange;
		GameObject target;


		// Use this for initialization
		void Start () {

			targetInRange = new List<GameObject> ();


			CircleCollider2D collider = GetComponent <CircleCollider2D> ();
			collider.radius = visionRadius;



		}

		// Update is called once per frame
		void Update () {

			time += Time.deltaTime*1;


				


				

					// Make yure enought time has passed to fire the bullet
				
				


			} 


		



		void OnTriggerEnter2D(Collider2D collider){

			if (targetInRange.Count == 0) {
				target = collider.gameObject;
			}

			targetInRange.Add (collider.gameObject);
			if (time >= attackSpeed) {

			//Debug.Log ("FIRE!");
			GameObject bulletClone = Instantiate (bullet, transform.position, Quaternion.identity);
			Bullet bulletScript = bulletClone.GetComponent <Bullet> ();


			time = 0f;

		}

		}


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
