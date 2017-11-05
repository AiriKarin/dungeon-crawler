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
            gameData.GetComponent<GameData>().inventorySpace[0] = gameData.GetComponent<GameData>().items[0];
            Destroy(gameObject);
        }
    }

}