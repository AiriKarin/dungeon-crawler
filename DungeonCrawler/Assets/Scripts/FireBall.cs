using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject gameData;

    void Awake()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
    }

    void Update () {
        if (gameData.GetComponent<GameData>().torches[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {
            gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)] = true;
            Destroy(gameObject);
        }

        if (gameData.GetComponent<GameData>().map[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {
            transform.position += transform.forward * 3 * Time.deltaTime;
        }else
        {
            Destroy(gameObject);
        }
    }
}
