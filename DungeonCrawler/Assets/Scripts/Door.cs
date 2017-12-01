//Airi Karin
//Github Game Jam
//Interactable Object - Door
//11/4/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject {
    private Transform MyTransform;
    private bool doorOpen = false;
    private Vector3 newPos;
    private Vector2 doorPos;
    private Vector3 openPos;
    private Vector3 closedPos;
    private bool locked;

    void Start()
    {
        base.Start();
        MyTransform = transform;
        newPos = transform.position;
        closedPos = newPos;
        openPos = newPos + new Vector3(0, .95f, 0);
        if (objectPos == new Vector2(11, 11))
        {
            locked = true;
        }
    }

    void OnMouseDown()
    {
        if (canInteract)
        {
            if (gameData.GetComponent<GameData>().inventorySpace[0] == gameData.GetComponent<GameData>().items[1])
            {
                locked = false;
                gameData.GetComponent<GameData>().inventorySpace[0] = null;
            }
            else if (gameData.GetComponent<GameData>().inventorySpace[1] == gameData.GetComponent<GameData>().items[1])
            {
                locked = false;
                gameData.GetComponent<GameData>().inventorySpace[1] = null;
            }
        }

        if (!locked)
        {
            if (MyTransform.position == newPos && gameData.GetComponent<GameData>().playerPos != doorPos && gameData.GetComponent<GameData>().canMove && canInteract)
            {
                {
                    if (!doorOpen)
                    {
                        doorOpen = true;
                        newPos = openPos;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    else if (doorOpen)
                    {
                        doorOpen = false;
                        newPos = closedPos;
                        gameData.GetComponent<GameData>().map[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = false;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
    }

    void Update()
    {
        if (gameData.GetComponent<GameData>().playerPos == objectPos + new Vector2(1, 0) || gameData.GetComponent<GameData>().playerPos == objectPos - new Vector2(1, 0) || gameData.GetComponent<GameData>().playerPos == objectPos + new Vector2(0, 1) || gameData.GetComponent<GameData>().playerPos == objectPos - new Vector2(0, 1) && MyTransform.position == newPos)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
        MyTransform.position = Vector3.MoveTowards(MyTransform.position, newPos, 1.5f * Time.deltaTime);

        if (MyTransform.position == newPos)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        if (MyTransform.position == openPos)
        {
            gameData.GetComponent<GameData>().map[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = true;
        }
    }
}