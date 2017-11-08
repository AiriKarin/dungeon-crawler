//Airi Karin
//Github Game Jam
//Interactable Object - Lever
//11/7/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject {
    private bool leverPulled;
    private Vector3 pulledPos;

    private void Start()
    {
        base.Start();
        pulledPos = transform.parent.rotation.eulerAngles + new Vector3(0, 0, -90);
    }

    private void OnMouseDown()
    {
        leverPulled = true;
    }

    private void Update()
    {
        base.Update();
        if (leverPulled)
        {
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, Quaternion.Euler(pulledPos.x, pulledPos.y, pulledPos.z), 200f * Time.deltaTime);
            gameData.GetComponent<GameData>().map[10, 8] = true;
        }
    }
}
