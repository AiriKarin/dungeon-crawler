using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : Fade {

    // Use this for initialization
    private void Start()
    {
        //make a tiny black texture
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 1));
        blk.Apply();
        alph = 1;
    }
    // Update is called once per frame
    void Update () {
        if (alph > 0 && !fade)
        {
            alph -= Time.deltaTime * .8f;
            if (alph < 0) { alph = 0f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
            blk.Apply();
        }
    }
}
