//Airi Karin
//Github Game Jam
//Interactable Object - Door
//11/4/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject {
    private bool doorOpen = false;
    private Vector3 newPos;
    private Vector2 doorPos;
    private bool locked;

    void Start()
    {
        base.Start();
        newPos = transform.position;
        if (objectPos == new Vector2(11, 11))
        {
            locked = true;
        }
    }

    void OnMouseDown()
    {
        if (gameData.GetComponent<GameData>().inventorySpace[1] != null)
        {
            locked = false;
            gameData.GetComponent<GameData>().inventorySpace[1] = null;
        }
        if (!locked)
        {
            if (transform.position == newPos && gameData.GetComponent<GameData>().playerPos != doorPos && gameData.GetComponent<GameData>().canMove && canInteract)
            {
                {
                    if (!doorOpen)
                    {
                        doorOpen = true;
                        newPos = transform.position + new Vector3(0, .95f, 0);
                        gameData.GetComponent<GameData>().map[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = true;
                    }
                    else if (doorOpen)
                    {
                        doorOpen = false;
                        newPos = transform.position - new Vector3(0, .95f, 0);
                        gameData.GetComponent<GameData>().map[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = false;
                    }
                }
            }
        }
    }

    void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, newPos, 2f * Time.deltaTime);
    }

}