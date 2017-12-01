using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour {

    public GameObject gameData;

    void Awake()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
    }

    void Update()
    {
        if (gameData.GetComponent<GameData>().torches[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {
            gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)] = false;
            Destroy(gameObject);
        }

        if (gameData.GetComponent<GameData>().map[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {
            transform.position += transform.forward * 2.5f * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
