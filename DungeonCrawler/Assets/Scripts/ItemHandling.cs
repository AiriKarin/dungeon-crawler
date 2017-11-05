//Airi Karin
//Github Game Jam
//Item Handling 
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandling : MonoBehaviour {
    public GameObject gameData;

    private void Start()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        gameData.GetComponent<GameData>().items = new GameObject[3];
        gameData.GetComponent<GameData>().inventorySpace = new GameObject[3];
        //Set the items that exist in the game
        gameData.GetComponent<GameData>().items[0] = (GameObject)Resources.Load("Items/Rock", typeof(GameObject));
        gameData.GetComponent<GameData>().items[1] = (GameObject)Resources.Load("Items/Key", typeof(GameObject));
    }

    private void Update () {
        if (Input.GetKeyDown("x")&&!(gameData.GetComponent<GameData>().inventorySpace[0] == null) && (gameData.GetComponent<GameData>().canMove)){
            Instantiate(gameData.GetComponent<GameData>().items[0], transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            gameData.GetComponent<GameData>().inventorySpace[0] = null;
        }
    }
}