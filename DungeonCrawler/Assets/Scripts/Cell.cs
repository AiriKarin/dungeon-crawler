using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public GameObject gameData;
    private Vector3 newPos;

    private void Start()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        newPos = transform.position;
    }
    void Update () {
        if (gameData.GetComponent<GameData>().map[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {     
            newPos = new Vector3(transform.position.x, 1.4f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPos, 2f * Time.deltaTime);
        }
    }
}
