using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {
    private float x;
    public bool lit;

    void Update() {
        if (lit)
        {
            x = Random.Range(-.6f, .6f);
            gameObject.GetComponent<Light>().intensity += x * Time.deltaTime;
            gameObject.GetComponent<Light>().range += x * Time.deltaTime;

            if (gameObject.GetComponent<Light>().intensity > .7 || gameObject.GetComponent<Light>().intensity < .3)
            {
                gameObject.GetComponent<Light>().intensity = .5f;
            }
            if (gameObject.GetComponent<Light>().range > 6 || gameObject.GetComponent<Light>().range < 2)
            {
                gameObject.GetComponent<Light>().range = 4;
            }
        }
    }
}
