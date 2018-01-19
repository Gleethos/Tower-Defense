using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;
	public GameObject EnemyAir;
	public GameObject EnemyFire;
	public GameObject EnemyWater;
	public GameObject EnemyStone;
	public GameObject EnemySmoke;
	private float timer = 10f;
	private int numberOfEnemies = 11;
	private int wave = 1;
	private float wavebreak = 20f;

    // Use this for initialization
    void Start () {
		


    }



	// Update is called once per frame
	void Update () {

		//Wave HUD 
		Text waveText;
		GameObject waveHUD = GameObject.Find ("WaveVariable");
		waveText = waveHUD.GetComponent<Text> ();
		waveText.text = "Wave: \t" + wave + "/5";

		timer = timer - 1 * Time.deltaTime;

		if (wave == 1) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (EnemyFire).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 2f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				wavebreak = wavebreak - 1 * Time.deltaTime;
				if (wavebreak <= 0) {
					wave++;
					numberOfEnemies = 22;
					wavebreak = 20f;
				}
			}
		} else if (wave == 2) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (EnemyWater).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 2f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				wavebreak = wavebreak - 1 * Time.deltaTime;
				if (wavebreak <= 0) {
					wave++;
					numberOfEnemies = 33;
					wavebreak = 20f;
				}
			}
		} else if (wave == 3) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (EnemyAir).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 1f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				wavebreak = wavebreak - 1 * Time.deltaTime;
				if (wavebreak <= 0) {
					wave++;
					numberOfEnemies = 44;
					wavebreak = 30f;
				}
			}
		} else if (wave == 4) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (EnemyStone).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 1f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				wavebreak = wavebreak - 1 * Time.deltaTime;
				if (wavebreak <= 0) {
					wave++;
					numberOfEnemies = 1;
					wavebreak = 50f;
				}
			}
		} else if (wave == 5) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (EnemySmoke).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 2f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				wavebreak = wavebreak - 1 * Time.deltaTime;
				if (wavebreak <= 0) {
					wave++;
					numberOfEnemies = 20;
				}
			}
		} else if (wave == 6) {
			if (timer <= 0 && numberOfEnemies > 0) {
				Instantiate (testEnemyPrefab).GetComponent<MoveEnemy> ().waypoints = waypoints;
				timer = 1f;
				numberOfEnemies--;
			} else if (timer <= 0 && numberOfEnemies <= 0)  {
				//Debug.Log ("Victory!");
				//GAME OVER
				Text overText;
				GameObject overHUD = GameObject.Find ("WinLoose");
				overText = overHUD.GetComponent<Text> ();
				overText.text = "VICTORY !";
			}
		}
		
	}
}
