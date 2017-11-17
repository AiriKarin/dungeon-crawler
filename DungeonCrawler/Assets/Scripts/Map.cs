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
    public int[,] doorMap;
    public GameObject gameData;
    private GameObject floor;
    private GameObject wall;
    private GameObject ceiling;
    private GameObject pillar;
    private GameObject molding;
    private GameObject door;
    private GameObject cell;
    private int mapSize;
    private TextAsset textMap;
    private TextAsset doorTextMap;

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
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        textMap = (TextAsset)Resources.Load("mapFile", typeof(TextAsset));
        doorTextMap = (TextAsset)Resources.Load("doorFile", typeof(TextAsset));

        gameData.GetComponent<GameData>().cellPos = new Vector2[5];

        //Read the map file and create a boolean version, Read the door map file and creat the int version
        string[] mapLines = textMap.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        string[] doorMapLines = doorTextMap.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        map = new bool[mapLines.Length, mapLines.Length];
        doorMap = new int[doorMapLines.Length, doorMapLines.Length];
        mapSize = mapLines.Length;
        int[,] spaces = new int[mapLines.Length, mapLines.Length];

        for (int i = 0; i < mapLines.Length; i++)
        {
            string st = mapLines[i];
            string st2 = doorMapLines[i];
            string[] nums = st.Split(new[] { ',' });
            string[] nums2 = st2.Split(new[] { ',' });

            for (int j = 0; j < nums.Length; j++)
            {
                int val;
                int val2;
                if (int.TryParse(nums[j], out val))
                    map[i, j] = (1 == val);
                else
                    map[i, j] = false;
                if (int.TryParse(nums2[j], out val2))
                    doorMap[i, j] = val2;
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

        //Using the door integer array, place the doors and cells on the map
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (doorMap[i, j] == 1)
                {
                    if (map[i, j + 1] || map[i, j - 1]) { 
                        Instantiate(door, new Vector3(i, .5f, j), Quaternion.Euler(0, 90, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                    }
                    if (map[i + 1, j] || map[i - 1, j])
                    {
                        Instantiate(door, new Vector3(i, .5f, j), Quaternion.Euler(0, 0, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                    }
                }
                if (doorMap[i, j] == 2)
                {
                    if (map[i + 1, j] && !map[i - 1, j])
                    {
                        Instantiate(cell, new Vector3(i, .5f, j), Quaternion.Euler(0, 90, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                        markCellPos(i, j);
                    }
                    if (map[i - 1, j] && !map[i + 1, j])
                    {
                        Instantiate(cell, new Vector3(i, .5f, j), Quaternion.Euler(0, -90, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                        markCellPos(i, j);
                    }
                    if (map[i, j+1] && !map[i, j-1])
                    {
                        Instantiate(cell, new Vector3(i, .5f, j), Quaternion.Euler(0, 0, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                        markCellPos(i, j);
                    }
                    if (map[i, j-1] && !map[i, j+1])
                    {
                        Instantiate(cell, new Vector3(i, .5f, j), Quaternion.Euler(0, 180, 0));
                        gameData.GetComponent<GameData>().map[i, j] = false;
                        markCellPos(i,j);
                    }
                    else
                    {
                        if (map[i, j])
                        {
                            Instantiate(cell, new Vector3(i, .5f, j), Quaternion.Euler(0, 180, 0));
                            gameData.GetComponent<GameData>().map[i, j] = false;
                            markCellPos(i,j);
                        }
                    }
                }
            }
        }
    }

    void markCellPos(int i,int j)
    {
        for (int x = 0; x < 4; x++)
        {
            if (gameData.GetComponent<GameData>().cellPos[x] == new Vector2(0, 0))
            {
                gameData.GetComponent<GameData>().cellPos[x] = new Vector2(i, j);
                return;
            }
        }
    }
}