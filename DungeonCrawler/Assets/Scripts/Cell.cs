//Airi Karin
//Github Game Jam
//Cell
//11/5/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public GameObject gameData;
    private Vector3 newPos;
    private Transform MyTransform;

    private void Start()
    {
        MyTransform = transform;
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        newPos = MyTransform.position;
    }

    void Update () {
        if (gameData.GetComponent<GameData>().map[Mathf.RoundToInt(MyTransform.position.x), Mathf.RoundToInt(MyTransform.position.z)])
        {
            newPos = new Vector3(MyTransform.position.x, 1.4f, MyTransform.position.z);
            if (MyTransform.position != newPos)
            {
                MyTransform.position = Vector3.MoveTowards(MyTransform.position, newPos, 2f * Time.deltaTime);
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }else
        {
            newPos = new Vector3(MyTransform.position.x, .5f, MyTransform.position.z);
            if (MyTransform.position != newPos)
            {
                MyTransform.position = Vector3.MoveTowards(MyTransform.position, newPos, 2f * Time.deltaTime);
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
