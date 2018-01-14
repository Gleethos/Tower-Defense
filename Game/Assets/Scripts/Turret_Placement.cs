using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Placement : MonoBehaviour {

    [SerializeField]
    private GameObject[] Turret;

    GameObject dummyTurret;

    bool itemAttached = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (itemAttached) { print("Item attached to mouse coursor! "); checkInput(); }

    }


    private void checkInput() {
        if (Input.GetMouseButton(0))
        { itemAttached = false; print("Item deattached!"); }
        else {dummyTurret.transform.position = new Vector3((Input.mousePosition.x-590)/25, (Input.mousePosition.y-475)/25, 2);
            print("Mouse position X:" + Input.mousePosition.x + "; Mouse position Y:" + Input.mousePosition.y + "; ");
        }
        
    }
		 

    public void getTurret(int towerIndex)
        {
        print("Mouse position X:"+Input.mousePosition.x+"; Mouse position Y:"+ Input.mousePosition.y+"; ");
        dummyTurret = Instantiate(Turret[towerIndex]);
        dummyTurret.transform.position = new Vector3((Input.mousePosition.x-590)/25, (Input.mousePosition.y-475)/25, 2);
        itemAttached = true;
        }


    }





