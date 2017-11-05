//Airi Karin
//Github Game Jam
//Map Generator
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public bool[,] map;
    public GameObject gameData;
    private GameObject floor;
    private GameObject wall;
    private GameObject ceiling;
    private GameObject pillar;
    private GameObject molding;
    private GameObject door;
    private GameObject cell;
    private GameObject rock;
    private GameObject key;
    private int mapSize;
    private TextAsset textMap;

    public void Start()
    {
        //Load resources necessary to read and generate the dungeon
        floor = (GameObject)Resources.Load("MapObjects/Floor", typeof(GameObject));
        wall = (GameObject)Resources.Load("MapObjects/Wall", typeof(GameObject));
        ceiling = (GameObject)Resources.Load("MapObjects/Ceiling", typeof(GameObject));
        pillar = (GameObject)Resources.Load("MapObjects/Pillar", typeof(GameObject));
        molding = (GameObject)Resources.Load("MapObjects/Molding", typeof(GameObject));
        door = (GameObject)Resources.Load("MapObjects/Door", typeof(GameObject));
        cell = (GameObject)Resources.Load("MapObjects/Cell", typeof(GameObject));
        rock = (GameObject)Resources.Load("Items/Rock", typeof(GameObject));
        key = (GameObject)Resources.Load("Items/Key", typeof(GameObject));
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        textMap = (TextAsset)Resources.Load("mapFile", typeof(TextAsset));

        //Read the map file and create a boolean version
        string[] lines = textMap.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        map = new bool[lines.Length, lines.Length];
        mapSize = lines.Length;
        int[,] spaces = new int[lines.Length, lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string st = lines[i];
            string[] nums = st.Split(new[] { ',' });
     
            for (int j = 0; j < nums.Length; j++)
            {
                int val;
                if (int.TryParse(nums[j], out val))
                    map[i, j] = (1==val);
                else
                    map[i, j] = false;
            }
        }
        gameData.GetComponent<GameData>().map = map;
        generateMap();
    }

    //Using the boolean map, create the 3D representation of the map
    void generateMap()
    {
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                if(map[i, j])
                {
                    //Span floor and ceiling tiles
                    Instantiate(floor, new Vector3(i,0,j), Quaternion.identity);
                    Instantiate(ceiling, new Vector3(i, 1f, j), Quaternion.identity);
                    //Spawn all walls
                    if (!map[i+1, j])
                    {
                        Instantiate(wall, new Vector3(i+.5f, .5f, j), Quaternion.identity);
                        Instantiate(molding, new Vector3(i + .5f, .02f, j), Quaternion.Euler(0, 90, 0));
                        Instantiate(molding, new Vector3(i + .5f, .98f, j), Quaternion.Euler(0, 90, 0));
                    }
                    if (!map[i-1, j])
                    {
                        Instantiate(wall, new Vector3(i-.5f, .5f, j), Quaternion.identity);
                        Instantiate(molding, new Vector3(i - .5f, .02f, j), Quaternion.Euler(0, 90, 0));
                        Instantiate(molding, new Vector3(i - .5f, .98f, j), Quaternion.Euler(0, 90, 0));
                    }
                    if (!map[i, j+1])
                    {
                        Instantiate(wall, new Vector3(i, .5f, j+.5f), Quaternion.Euler(0,90,0));
                        Instantiate(molding, new Vector3(i, .02f, j + .5f), Quaternion.identity);
                        Instantiate(molding, new Vector3(i, .98f, j + .5f), Quaternion.identity);
                    }
                    if (!map[i, j-1])
                    {
                        Instantiate(wall, new Vector3(i, .5f, j-.5f), Quaternion.Euler(0,90,0));
                        Instantiate(molding, new Vector3(i, .02f, j-.5f), Quaternion.identity);
                        Instantiate(molding, new Vector3(i, .98f, j - .5f), Quaternion.identity);
                    }
                    //Spawn Corner Decorations
                    if (!map[i+1,j]&& !map[i, j + 1])
                    {
                        Instantiate(pillar, new Vector3(i+.5f,.55f,j+.5f), Quaternion.identity);
                    }
                    if (!map[i + 1, j] && !map[i, j - 1])
                    {
                        Instantiate(pillar, new Vector3(i + .5f, .55f, j - .5f), Quaternion.identity);
                    }
                    if (!map[i - 1, j] && !map[i, j + 1])
                    {
                        Instantiate(pillar, new Vector3(i - .5f, .55f, j + .5f), Quaternion.identity);
                    }
                    if (!map[i - 1, j] && !map[i, j - 1])
                    {
                        Instantiate(pillar, new Vector3(i - .5f, .55f, j - .5f), Quaternion.identity);
                    }
                    if (map[i, j - 1]&& map[i + 1, j] && !map[i + 1, j - 1])
                    {
                        Instantiate(pillar, new Vector3(i + .5f, .55f, j - .5f), Quaternion.identity);
                    }
                    if (map[i, j + 1] && map[i + 1, j] && !map[i + 1, j + 1])
                    {
                        Instantiate(pillar, new Vector3(i + .5f, .55f, j + .5f), Quaternion.identity);
                    }
                    if (map[i, j + 1] && map[i + 1, j] && !map[i + 1, j + 1])
                    {
                        Instantiate(pillar, new Vector3(i + .5f, .55f, j + .5f), Quaternion.identity);
                    }
                    if (map[i, j - 1] && map[i + 1, j] && !map[i + 1, j - 1])
                    {
                        Instantiate(pillar, new Vector3(i + .5f, .55f, j - .5f), Quaternion.identity);
                    }
                    if (map[i, j - 1] && map[i - 1, j] && !map[i - 1, j - 1])
                    {
                        Instantiate(pillar, new Vector3(i - .5f, .55f, j - .5f), Quaternion.identity);
                    }
                    if (map[i, j + 1] && map[i - 1, j] && !map[i - 1, j + 1])
                    {
                        Instantiate(pillar, new Vector3(i - .5f, .55f, j + .5f), Quaternion.identity);
                    }
                }                   
            }
        }
        //Create the doors and set them to be impassable to the player (find a neater way to do this later)
        Instantiate(door, new Vector3(11, .5f, 5), Quaternion.Euler(0, 90, 0));
        gameData.GetComponent<GameData>().map[11, 5] = false;
        Instantiate(door, new Vector3(11, .5f, 11), Quaternion.Euler(0, 90, 0));
        gameData.GetComponent<GameData>().map[11, 11] = false;
        Instantiate(door, new Vector3(11, .5f, 15), Quaternion.Euler(0, 90, 0));
        gameData.GetComponent<GameData>().map[11, 15] = false;
        Instantiate(door, new Vector3(9, .5f, 13), Quaternion.identity);
        gameData.GetComponent<GameData>().map[9, 13] = false;
        Instantiate(door, new Vector3(13, .5f, 13), Quaternion.identity);
        gameData.GetComponent<GameData>().map[13, 13] = false;

        //Create the barred passages
        Instantiate(cell, new Vector3(10, .5f, 8), Quaternion.Euler(0, 90, 0));
        gameData.GetComponent<GameData>().map[10, 8] = false;
        Instantiate(cell, new Vector3(12, .5f, 8), Quaternion.Euler(0, -90, 0));
        gameData.GetComponent<GameData>().map[12, 8] = false;

        //Place items on the map
        Instantiate(rock, new Vector3(10.25f, .1f, 7.9f), Quaternion.identity);
        Instantiate(key, new Vector3(9.7f, .1f, 8.3f), Quaternion.Euler(0, 105, 0));
    }
}