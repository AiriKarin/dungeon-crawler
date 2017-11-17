//Airi Karin
//Github Game Jam
//InteractableObject - Key
//11/5/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractableObject {

    void OnMouseDown()
    {
        if (canInteract && gameData.GetComponent<GameData>().map[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)])
        {
            if (gameData.GetComponent<GameData>().inventorySpace[0] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[0] = gameData.GetComponent<GameData>().items[1];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[1] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[1] = gameData.GetComponent<GameData>().items[1];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[2] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[2] = gameData.GetComponent<GameData>().items[1];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[3] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[3] = gameData.GetComponent<GameData>().items[1];
                Destroy(gameObject);
            }
        }
    }
}
