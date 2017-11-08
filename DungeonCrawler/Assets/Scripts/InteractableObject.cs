//Airi Karin
//Github Game Jam
//Interactable Object
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    private Shader defaultShader;
    private Shader outLineShader;
    private Renderer rend;
    public GameObject gameData;
    public Vector2 objectPos;
    public bool canInteract;

    public void Start()
    {
        defaultShader = Shader.Find("Standard");
        outLineShader = (Shader)Resources.Load("Shader/outlineShader", typeof(Shader));
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        objectPos = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseOver()
    {
        if (canInteract)
        {
            rend.material.shader = outLineShader;
        }
    }

    private void OnMouseExit()
    {
        rend.material.shader = defaultShader;
    }

    public void Update()
    {
        if (gameData.GetComponent<GameData>().playerPos == objectPos + new Vector2(1, 0) || gameData.GetComponent<GameData>().playerPos == objectPos - new Vector2(1, 0) || gameData.GetComponent<GameData>().playerPos == objectPos + new Vector2(0, 1) || gameData.GetComponent<GameData>().playerPos == objectPos - new Vector2(0, 1))
        {
            canInteract = true;
        }else if (gameData.GetComponent<GameData>().playerPos == objectPos)
        {
            canInteract = true;
        }else
        {
            canInteract = false;
        }
    }
}