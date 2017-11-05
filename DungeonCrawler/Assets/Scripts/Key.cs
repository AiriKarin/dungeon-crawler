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
            gameData.GetComponent<GameData>().inventorySpace[1] = gameData.GetComponent<GameData>().items[1];
            Destroy(gameObject);
        }
    }
}
