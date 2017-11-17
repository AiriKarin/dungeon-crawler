//Airi Karin
//Github Game Jam
//Interactable Object - Rock 
//11/3/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : InteractableObject {

    void OnMouseDown()
    {
        if (canInteract)
        {
            if (gameData.GetComponent<GameData>().inventorySpace[0] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[0] = gameData.GetComponent<GameData>().items[0];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[1] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[1] = gameData.GetComponent<GameData>().items[0];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[2] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[2] = gameData.GetComponent<GameData>().items[0];
                Destroy(gameObject);
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[3] == null)
            {
                gameData.GetComponent<GameData>().inventorySpace[3] = gameData.GetComponent<GameData>().items[0];
                Destroy(gameObject);
            }
        }
    }
}