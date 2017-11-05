using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Texture2D blk;
    public Texture2D fuzz;
    public bool fade;
    public bool flash;
    public bool wait;
    public float timer = 10;
    public float alph = 1;

    void Start()
    {
        //make a tiny black texture
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 1));
        blk.Apply();
    }

    // put it on your screen
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
        if (flash)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fuzz);
        }
    }

    void Update()
    {
        if (alph > 0 && !fade)
        {
            alph -= Time.deltaTime * .2f;
            if (alph < 0) { alph = 0f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
            blk.Apply();
        }
        if (timer <= 0 && !wait)
        {
            flash = true;
            wait = true;
            timer = Random.Range(.1f,2f);
        }
        else
        {
            flash = false;
            timer -= Time.deltaTime * .3f;
            wait = false;
        }

        if (Input.GetKey("space")){
            fade = true;
        }

        if (fade)
        {
            if (alph <= 1)
            {
                alph += Time.deltaTime * .2f;
                if (alph >= 1)
                {
                    SceneManager.LoadScene("Game");
                }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
        }
    }
}
