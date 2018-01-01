using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
//using System;

public class MapCreator : MonoBehaviour {

	Random dice = new Random();
	[SerializeField]
	private int testMap;
	[SerializeField] 
	private MapManager Map;
	[SerializeField] 
	private GameObject[] Tile;
	[SerializeField] 
	private GameObject[] TileCorner;
		
	public int[,] testMap0 = new int[,]{
		{0,0,0,0,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,0,0,0,0},
		{0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,5,5,1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,0,0,0,0},
		{1,4,1,1,3,3,5,1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,0,0,0,0},
		{1,4,1,1,3,5,5,1,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,0,0,0,0},
		{1,4,2,2,2,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,4,2,2,2,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,4,2,2,2,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,4,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
		{1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0}
	};

	// Use this for initialization
	void Start () {
	Map = new MapManager();
		createLevel (Map.getMap(), 199);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	private void createLevel(int[,] map){
	float l = map.Length;double a = Mathf.Pow (l, (1/2)); 
		print ("HEEEEEEEY: "+a);
	createLevel (map, a);
	}
		
	private void createLevel(int[,] map, double a){
	print ("Map is being built now! ...");
	double length = a;
		int shift =(int)length/2;

	for(int y = 0; y < length; y++)
		{for(int x = 0; x < length; x++){	
					int rotationID = Random.Range(0, 4);
					if(map[y,x]<8&&map[y,x]>=0){print ("placing TileID["+y+"]["+x+"]: "+map[y,x]+"\n");

						if(rotationID==0){placeTileAt(x-shift, y-shift, map[y,x], 0, 0);}
						if(rotationID==1){placeTileAt(x-shift, y-shift, map[y,x], 0, 90);}
						if(rotationID==2){placeTileAt(x-shift, y-shift, map[y,x], 0, 180);}
						if(rotationID==3){placeTileAt(x-shift, y-shift, map[y,x], 0, 270);}
					}
	
				smoothAt (x, y, -shift, -shift, map); //Corner Tiles Placement
		    
				}
				
			}

		}
		
	//Placement Functions:

	private void placeTileAt(int x, int y, int tileID)//Tile Placemen
	{float tileSize = Tile[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	 GameObject newTile = Instantiate(Tile[tileID]);
	 newTile.transform.position = new Vector3(tileSize*x, -tileSize*y, 0);}

	private void placeTileAt(int x, int y, int tileID, int layerID)//Tile Placement with Layer Parameters
	{float tileSize = Tile[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	 GameObject newTile = Instantiate(Tile[tileID]);
	 newTile.transform.position = new Vector3(tileSize*x, -tileSize*y, layerID);}

	private void placeTileAt(int x, int y, int tileID, int layerID, int rotation)//Tile Placement with Layer and Rotation Parameters
	{float tileSize = Tile[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x; 
     GameObject newTile = Instantiate (Tile[tileID], new Vector3 (tileSize * x, -tileSize * y, layerID), Quaternion.Euler (0, 0, rotation));}



	private void placeCornerTileAt(int x, int y, int tileID, int layerID, int rotation)//Corner Tile Placement with Layer and Rotation Parameters
	{if(tileID>7){print("...corner ID "+tileID+" does not exist! ");}
	 else{float tileSize = Tile[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		  GameObject newTile = Instantiate (TileCorner[tileID], new Vector3 (tileSize * x, -tileSize * y, layerID), Quaternion.Euler (0, 0, rotation));}}



	private void smoothAt(int x, int y, int xShift, int yShift, int[,] map)
	{if (map [y + 1, x + 1] == map [y, x + 1] & map [y + 1, x + 1] == map [y + 1, x] & map [y + 1, x + 1] != map [y, x]) 
		{placeCornerTileAt (x+xShift, y+yShift, map [y + 1, x + 1], -1, 180);} 
	else 
	    {if(map[y,x+1]==map[y+1,x]&map[y+1,x]!=map[y,x])
			{placeCornerTileAt (x+xShift, y+yShift, map [y + 1,x], -1, 180);}	
		}

	if(x>0&&y>0){
			if (map [y - 1, x - 1] == map [y, x - 1] & map [y - 1, x - 1] == map [y - 1, x] & map [y - 1, x - 1] != map [y, x]) {
				placeCornerTileAt (x+xShift, y+yShift, map [y - 1, x - 1], -1, 0);
			} else {
				if(map[y,x-1]==map[y-1,x]&map[y,x-1]!=map[y,x])
				{placeCornerTileAt (x+xShift, y+yShift, map [y,x - 1], -1, 0);}
			}
		}
		
		if(y>0){
			if (map [y - 1, x + 1] == map [y, x + 1] & map [y - 1, x + 1] == map [y - 1, x] & map [y - 1, x + 1] != map [y, x]) {
				placeCornerTileAt (x+xShift, y+yShift, map [y - 1, x + 1], -1, 270);
			} 
			else {
				if(map[y,x+1]==map[y-1,x]&map[y,x+1]!=map[y,x])
				{placeCornerTileAt (x+xShift, y+yShift, map [y - 1,x], -1, 270);}
			}

		}

		if (x > 0) {
			if (map [y + 1, x - 1] == map [y, x - 1] & map [y + 1, x - 1] == map [y + 1, x] & map [y + 1, x - 1] != map [y, x]) {
				placeCornerTileAt (x+xShift, y+yShift, map [y + 1, x - 1], -1, 90);
				}else {
				if(map[y,x-1]==map[y+1,x]&map[y,x-1]!=map[y,x])
				{placeCornerTileAt (x+xShift, y+yShift, map [y,x - 1], -1, 90);}
				}	
		}
	}
		
	//0 - dirt
	//1 -grass
	//2 -darkGrass
	//3 -stone
	//4 -sand
	//5 -water
}
