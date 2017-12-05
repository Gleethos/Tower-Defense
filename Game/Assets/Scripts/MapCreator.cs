using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour {

	Random dice = new Random();

	[SerializeField]
	private int testMap;

	[SerializeField] 
	private Map TileMap;

	[SerializeField] 
	private GameObject[] Tile;
	[SerializeField] 
	private GameObject[] TileCorner;
		
	public int[,] testMap2
	= new int[,]{
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
		
		createLevel (TileMap.testMapArray);



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void createLevel(int[,] map){

	float tileSize=Tile[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	int length = 15;
		int counter = 0;;
	for(int y = 0; y < length; y++)
		{for(int x = 0; x < length; x++){
				int rotationID = Random.Range(0, 4);
				if(rotationID==0){placeTileAt(x, y, map[y,x], 0, 0);}
				if(rotationID==1){placeTileAt(x, y, map[y,x], 0, 90);}
				if(rotationID==2){placeTileAt(x, y, map[y,x], 0, 180);}
				if(rotationID==3){placeTileAt(x, y, map[y,x], 0, 270);}
				//placeTileAt(x, y, testMap2[y,x]);
				smoothAt (x, y, map);
				//placeTileAt(x, y, 0, -1, 45);
				counter++;
			}

		}

	}
		

	private void placeTileAt(int x, int y, int tileID)
	{float tileSize = Tile[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	 GameObject newTile = Instantiate(Tile[tileID]);
	 newTile.transform.position = new Vector3(tileSize*x, -tileSize*y, 0);}

	private void placeTileAt(int x, int y, int tileID, int layerID)
	{float tileSize = Tile[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	 GameObject newTile = Instantiate(Tile[tileID]);
	 newTile.transform.position = new Vector3(tileSize*x, -tileSize*y, layerID);}

	private void placeTileAt(int x, int y, int tileID, int layerID, int rotation)
	{float tileSize = Tile[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
	 GameObject newTile = Instantiate (Tile[tileID], new Vector3 (tileSize * x, -tileSize * y, layerID), Quaternion.Euler (0, 0, rotation));
	}

	private void placeCornerTileAt(int x, int y, int tileID, int layerID, int rotation)
	{float tileSize = Tile[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		GameObject newTile = Instantiate (TileCorner[tileID], new Vector3 (tileSize * x, -tileSize * y, layerID), Quaternion.Euler (0, 0, rotation));
	}
		//Instantiate(grassTile);

	private void smoothAt(int x, int y, int[,] map)
	{
		if(map[y+1,x+1]==map[y,x+1]&map[y+1,x+1]==map[y+1,x]&map[y+1,x+1]!=map[y,x])
		{placeCornerTileAt (x, y, map [y + 1,x + 1], -1, 180);}

		if(map[y,x+1]==map[y+1,x]&map[y+1,x]!=map[y,x])
		{placeCornerTileAt (x, y, map [y + 1,x], -1, 180);}

		if(x>0&&y>0){
			if(map[y-1,x-1]==map[y,x-1]&map[y-1,x-1]==map[y-1,x]&map[y-1,x-1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y - 1,x - 1], -1, 0);}
		
			if(map[y,x-1]==map[y-1,x]&map[y,x-1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y,x - 1], -1, 0);}

		
			}
		
		if(y>0){
			if(map[y-1,x+1]==map[y,x+1]&map[y-1,x+1]==map[y-1,x]&map[y-1,x+1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y - 1,x +1], -1, 270);}
		
			if(map[y,x+1]==map[y-1,x]&map[y,x+1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y - 1,x], -1, 270);}
		}
		if (x > 0) {
			if(map[y+1,x-1]==map[y,x-1]&map[y+1,x-1]==map[y+1,x]&map[y+1,x-1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y + 1,x - 1], -1, 90);}
		
			if(map[y,x-1]==map[y+1,x]&map[y,x-1]!=map[y,x])
			{placeCornerTileAt (x, y, map [y,x - 1], -1, 90);}
		}





	}


		
	//0 - dirt
	//1 -grass
	//2 -darkGrass
	//3 -stone
	//4 -sand
	//5 -water
}
