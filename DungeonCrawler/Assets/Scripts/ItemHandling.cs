//Airi Karin
//Github Game Jam
//Item Handling 
//11/1/2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandling : MonoBehaviour {
    public GameObject gameData;
    private Texture2D inventoryBox;
    private Texture2D rock;
    private Texture2D key;

    private void Start()
    {
        gameData = (GameObject)Resources.Load("GameData", typeof(GameObject));
        gameData.GetComponent<GameData>().items = new GameObject[3];
        gameData.GetComponent<GameData>().inventorySpace = new GameObject[3];

        //Set the items that exist in the game
        gameData.GetComponent<GameData>().items[0] = (GameObject)Resources.Load("Items/Rock", typeof(GameObject));
        gameData.GetComponent<GameData>().items[1] = (GameObject)Resources.Load("Items/Key", typeof(GameObject));
        inventoryBox = (Texture2D)Resources.Load("Images/ItemBoundBox");
        rock = (Texture2D)Resources.Load("Images/Rock");
        key = (Texture2D)Resources.Load("Images/Key");
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width*.38f - inventoryBox.width/4, Screen.height*.92f - inventoryBox.height / 4, inventoryBox.width/2, inventoryBox.height/2), inventoryBox);
        GUI.DrawTexture(new Rect(Screen.width*.46f - inventoryBox.width/4, Screen.height*.92f - inventoryBox.height / 4, inventoryBox.width / 2, inventoryBox.height / 2), inventoryBox);
        GUI.DrawTexture(new Rect(Screen.width *.54f - inventoryBox.width/4, Screen.height*.92f - inventoryBox.height / 4, inventoryBox.width / 2, inventoryBox.height / 2), inventoryBox);
        GUI.DrawTexture(new Rect(Screen.width *.62f - inventoryBox.width/4, Screen.height*.92f - inventoryBox.height / 4, inventoryBox.width / 2, inventoryBox.height / 2), inventoryBox);

        if (gameData.GetComponent<GameData>().inventorySpace[0] != null)
        {
            GUI.DrawTexture(new Rect(Screen.width * .38f - rock.width / 4, Screen.height * .92f - rock.height / 4, rock.width / 2, rock.height / 2), rock);
        }
        if (gameData.GetComponent<GameData>().inventorySpace[1] != null)
        {
            GUI.DrawTexture(new Rect(Screen.width * .46f - key.width / 4, Screen.height * .92f - key.height / 4, key.width / 2, key.height / 2), key);
        }
    }

    private void Update () {
        if (Input.GetKeyDown("x")&&!(gameData.GetComponent<GameData>().inventorySpace[0] == null) && (gameData.GetComponent<GameData>().canMove)){
            Instantiate(gameData.GetComponent<GameData>().items[0], transform.position + new Vector3(0, .1f, 0), Quaternion.identity);
            gameData.GetComponent<GameData>().inventorySpace[0] = null;
        }
    }
}