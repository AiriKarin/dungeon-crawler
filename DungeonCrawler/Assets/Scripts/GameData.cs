﻿//Airi Karin
//Github Game Jam
//GameData
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
    public GameObject[] items;
    public GameObject[] inventorySpace;
    public bool[,] map;
    public bool canMove;
    public Vector2 playerPos;

    // Use this for initialization
    public void Start () {
        this.items = new GameObject[3];
        this.inventorySpace = new GameObject[3];
    }
}