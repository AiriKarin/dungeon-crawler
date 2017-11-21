//Airi Karin
//Github Game Jam
//LevelControl
//11/9/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

    private GameObject lever;
    private GameObject rock;
    private GameObject key;
    private GameObject torch;
    public GameObject gameData;

    private void Awake()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        lever = (GameObject)Resources.Load("MapObjects/Lever", typeof(GameObject));
        rock = (GameObject)Resources.Load("Items/Rock", typeof(GameObject));
        key = (GameObject)Resources.Load("Items/Key", typeof(GameObject));
        torch = (GameObject)Resources.Load("MapObjects/Torch", typeof(GameObject));
        placeObjects();
    }

    void placeObjects()
    {
        //Place objects on the map
        Instantiate(lever, new Vector3(9.525f,.45f,6f), Quaternion.identity);
        Instantiate(lever, new Vector3(9.525f,.45f,10f), Quaternion.identity);
        Instantiate(lever, new Vector3(12.475f,.45f,6f), Quaternion.Euler(0, 180, 0));
        Instantiate(lever, new Vector3(12.475f,.45f,10f), Quaternion.Euler(0, 180, 0));
        Instantiate(rock, new Vector3(10.25f,.1f,7.9f), Quaternion.identity);
        Instantiate(key, new Vector3(9.7f,.1f,8.3f), Quaternion.Euler(0, 105, 0));
        Instantiate(torch, new Vector3(10,.15f,19), Quaternion.identity);
        Instantiate(torch, new Vector3(12,.15f,19), Quaternion.identity);
        Instantiate(torch, new Vector3(1, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(21, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(6, .15f, 11), Quaternion.identity);
        Instantiate(torch, new Vector3(16, .15f, 11), Quaternion.identity);
        Instantiate(torch, new Vector3(18, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(4, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(10, .15f, 3), Quaternion.identity);
        Instantiate(torch, new Vector3(12, .15f, 3), Quaternion.identity);
        Instantiate(torch, new Vector3(10, .15f, 14), Quaternion.identity);
        Instantiate(torch, new Vector3(12, .15f, 14), Quaternion.identity);
        Instantiate(torch, new Vector3(12, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(10, .15f, 12), Quaternion.identity);
        Instantiate(torch, new Vector3(7, .15f, 14), Quaternion.identity);
        Instantiate(torch, new Vector3(3, .15f, 14), Quaternion.identity);
        Instantiate(torch, new Vector3(15, .15f, 14), Quaternion.identity);
        Instantiate(torch, new Vector3(19, .15f, 14), Quaternion.identity);
    }

    private void Update()
    {
        if (gameData.GetComponent<GameData>().switches[10, 6] && !gameData.GetComponent<GameData>().switches[12, 6] && gameData.GetComponent<GameData>().switches[10, 10] && !gameData.GetComponent<GameData>().switches[12, 10])
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[0].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[0].y)] = true;
        }
        else
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[0].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[0].y)] = false;
        }
        if (gameData.GetComponent<GameData>().switches[12, 6] && !gameData.GetComponent<GameData>().switches[10, 6] && !gameData.GetComponent<GameData>().switches[10, 10] && gameData.GetComponent<GameData>().switches[12, 10])
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[2].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[2].y)] = true;
        }
        else
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[2].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[2].y)] = false;
        }
        if (!gameData.GetComponent<GameData>().map[10, 8] && !gameData.GetComponent<GameData>().map[12, 8] && !gameData.GetComponent<GameData>().map[9, 13] && !gameData.GetComponent<GameData>().map[13, 13])
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[1].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[1].y)] = true;
        }
        else
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[1].x), Mathf.RoundToInt(gameData.GetComponent<GameData>().cellPos[1].y)] = false;
        }
    }
}
