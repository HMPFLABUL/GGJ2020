using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help : MonoBehaviour
{
    SpriteRenderer mySprite;
    SpriteRenderer solSprite;
    SpriteRenderer solSprite2;
    int siluetheCounter;

    private void Awake()
    {
        siluetheCounter = 0;
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        mySprite = sprites[0];
        solSprite = sprites[1];
        solSprite2 = sprites[2];
        sprites[0].enabled = true;
        sprites[1].enabled = false;
        sprites[2].enabled = false;
        sprites[2].color = Color.black;
    }
    private void OnMouseUp()
    {
        mySprite.enabled = true;
        solSprite.enabled = false;
        solSprite2.enabled = false;
    }
    private void OnMouseDown()
    {
        if (siluetheCounter < 6)
            siluetheCounter++;
        else
            solSprite2.color = Color.white;

        mySprite.enabled = false;
        solSprite.enabled = true;
        solSprite2.enabled = true;
    }
}
