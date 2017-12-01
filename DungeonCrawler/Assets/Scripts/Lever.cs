//Airi Karin
//Github Game Jam
//Interactable Object - Lever
//11/7/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject {
    private bool leverPulled;
    private Vector3 unPulledPos;
    private Vector3 pulledPos;

    private void Start()
    {
        base.Start();
        unPulledPos = transform.parent.rotation.eulerAngles;
        pulledPos = transform.parent.rotation.eulerAngles + new Vector3(0, 0, -90);
    }

    private void OnMouseDown()
    {
        if (transform.parent.rotation.eulerAngles == unPulledPos)
        {
            leverPulled = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            leverPulled = false;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        base.Update();
        if (leverPulled)
        {
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, Quaternion.Euler(pulledPos.x, pulledPos.y, pulledPos.z), 200f * Time.deltaTime);
            gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = true;
        }
        else if (!leverPulled)
        {
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, Quaternion.Euler(unPulledPos.x, unPulledPos.y, unPulledPos.z), 200f * Time.deltaTime);
            gameData.GetComponent<GameData>().switches[Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y)] = false;
        }
    }
}
