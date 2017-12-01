using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour {
    public GameObject gameData;
    public Transform MyTransform;

    public void Start()
    {
        MyTransform = transform;
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        gameData.GetComponent<GameData>().torches[Mathf.RoundToInt(MyTransform.position.x), Mathf.RoundToInt(MyTransform.position.z)] = true;
        gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(MyTransform.position.x), Mathf.RoundToInt(MyTransform.position.z)] = true;
    }

    public void Update()
    {
        if (!gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(MyTransform.position.x), Mathf.RoundToInt(MyTransform.position.z)])
        {
            gameObject.GetComponent<LightFlicker>().lit = false;
            gameObject.GetComponent<Light>().intensity = 0;
            gameObject.GetComponent<ParticleSystem>().startLifetime = 0;
            gameObject.GetComponent<AudioSource>().Stop();
        }
        else if (gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(MyTransform.position.x), Mathf.RoundToInt(MyTransform.position.z)])
        {
            gameObject.GetComponent<LightFlicker>().lit = true;
            gameObject.GetComponent<ParticleSystem>().startLifetime = 2;
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
