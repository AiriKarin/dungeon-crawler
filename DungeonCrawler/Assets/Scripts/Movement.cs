//Airi Karin
//Github Game Jam
//Player Movement 
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 pos = new Vector2(1, 1);
    public Vector2 dir;
    public int rotation;
    public bool canMove = true;
    public Vector3 newPos;
    public Vector3 newRot;
    public GameObject gameData;
    public GameObject fireBall;
    private bool[,] map;
    public int spellTracker;

    public void Start()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        fireBall = (GameObject)Resources.Load("Items/FireBall", typeof(GameObject));
    }

    //Set the players initial positional and rotational values
    void Awake()
    {
        rotation = 0;
        dir = new Vector2(0, 1);
        transform.position = new Vector3(pos.x, 0, pos.y);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }

    //Check the players input to see if the move is valid
    void moveCheck()
    {
        Vector2 startPos = pos;

        //Check the map to see if doors have been opened or closed
        map = gameData.GetComponent<GameData>().map;

        //Spell Casting System
        if (Input.GetKeyDown("k"))
        {
            spellTracker = 1;
        }
        else if (Input.GetKeyDown("l"))
        {
            if (spellTracker == 1)
            {
                spellTracker = 2;
            }
            else if (spellTracker == 4)
            {
                spellTracker = 5;
            }
            else
            {
                spellTracker = 0;
            }
        }
        else if (Input.GetKeyDown("j"))
        {
            if (spellTracker == 2)
            {
                spellTracker = 3;
            }
            else if (spellTracker == 1)
            {
                spellTracker = 4;
            }
            else
            {
                spellTracker = 0;
            }
        }
        else if (Input.GetKeyDown("i"))
        {
            if (spellTracker == 3)
            {
                Debug.Log("Water Spell");
                spellTracker = 0;
            }
            else if (spellTracker == 5)
            {
                Debug.Log("Fire Spell");
                Instantiate(fireBall, transform.position + new Vector3(0,.5f,0), transform.rotation);
                spellTracker = 0;
            }
        }

        //Turn Left
        if (Input.GetKey("a"))
        {
            canMove = false;
            if (dir.x == 1)
            {
                rotation = 0;
                dir = new Vector2(0, 1);
                return;
            }
            if (dir.y == 1)
            {
                rotation = -90;
                dir = new Vector2(-1, 0);
                return;
            }
            if (dir.x == -1)
            {
                rotation = 180;
                dir = new Vector2(0, -1);
                return;
            }
            if (dir.y == -1)
            {
                rotation = 90;
                dir = new Vector2(1, 0);
                return;
            }
        }

        //Turn Right
        if (Input.GetKey("d"))
        {
            canMove = false;
            if (dir.x == 1)
            {
                rotation = 180;
                dir = new Vector2(0, -1);
                return;
            }
            if (dir.y == 1)
            {
                rotation = 90;
                dir = new Vector2(1, 0);
                return;
            }
            if (dir.x == -1)
            {
                rotation = 0;
                dir = new Vector2(0, 1);
                return;
            }
            if (dir.y == -1)
            {
                rotation = -90;
                dir = new Vector2(-1, 0);
                return;
            }
        }

        //Move Forward
        if (Input.GetKey("w"))
        {
            canMove = false;
            pos = pos + dir;
        }

        //Move Backward
        if (Input.GetKey("s"))
        {
            canMove = false;
            pos = pos - dir;
        }

        //Strafe Left
        if (Input.GetKey("q")&&canMove)
        {
            canMove = false;
            if (dir.x == 1)
            {
                pos.y = pos.y + 1;
            }
            if (dir.x == -1)
            {
                pos.y = pos.y - 1;
            }
            if (dir.y == 1)
            {
                pos.x = pos.x - 1;
            }
            if (dir.y == -1)
            {
                pos.x = pos.x + 1;
            }
        }

        //Strafe Right
        if (Input.GetKey("e")&&canMove)
        {
            canMove = false;
            if (dir.x == 1)
            {
                pos.y = pos.y - 1;
            }
            if (dir.x == -1)
            {
                pos.y = pos.y + 1;
            }
            if (dir.y == 1)
            {
                pos.x = pos.x + 1;
            }
            if (dir.y == -1)
            {
                pos.x = pos.x - 1;
            }
        }

        //If a move is invalid, set the position back to the initial value
        if (!map[Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)]){
            pos = startPos;
            canMove = true;
        }
    }

    void Update ()
    {
        newPos = new Vector3(pos.x, 0, pos.y);
        newRot = new Vector3(0, rotation, 0);
        gameData.GetComponent<GameData>().playerPos = pos;

        //Move the player to the new position or rotation
        if (transform.position != newPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, 3f * Time.deltaTime);
        }
        if (transform.rotation != Quaternion.Euler(newRot.x, newRot.y, newRot.z))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(newRot.x, newRot.y, newRot.z), 350f * Time.deltaTime);
        }
        if (transform.position == newPos && transform.rotation == Quaternion.Euler(newRot.x, newRot.y, newRot.z))
        {
            canMove = true;
        }

        //Check for player input
        if (canMove)
        {               
            moveCheck();
        }
        gameData.GetComponent<GameData>().canMove = canMove;
    }
}