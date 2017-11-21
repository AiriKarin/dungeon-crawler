using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public GameObject gameData;

    private void Awake()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
    }

    // Update is called once per frame
    void Update () {
        if (gameData.GetComponent<GameData>().map[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z)])
        {
            transform.position += transform.forward * 3 * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
