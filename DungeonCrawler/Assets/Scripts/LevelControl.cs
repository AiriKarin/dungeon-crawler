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
    public GameObject gameData;

    private void Awake()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        lever = (GameObject)Resources.Load("MapObjects/Lever", typeof(GameObject));
        rock = (GameObject)Resources.Load("Items/Rock", typeof(GameObject));
        key = (GameObject)Resources.Load("Items/Key", typeof(GameObject));
        placeObjects();
    }

    void placeObjects()
    {
        //Place objects on the map
        Instantiate(lever, new Vector3(9.525f, .5f, 6f), Quaternion.identity);
        Instantiate(rock, new Vector3(10.25f, .1f, 7.9f), Quaternion.identity);
        Instantiate(key, new Vector3(9.7f, .1f, 8.3f), Quaternion.Euler(0, 105, 0));
    }
}
