using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;
	private float timer = 2f;
	private int numberOfEnemies = 30;

    // Use this for initialization
    void Start () {
		
        Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;

    }
	
	// Update is called once per frame
	void Update () {

		timer = timer - 1 * Time.deltaTime;

		if (timer <= 0 && numberOfEnemies > 0) {
			Instantiate (testEnemyPrefab).GetComponent<MoveEnemy> ().waypoints = waypoints;
			timer = 2f;
			numberOfEnemies--;
		}

		
	}
}
