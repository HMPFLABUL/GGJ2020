using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AlphaAnim : MonoBehaviour
{
    [SerializeField]
    bool reverse = false;
    SpriteRenderer rend;
    bool animate = false;
    float value = 0;
    [SerializeField]
    FloatVariable animSpeed;
    private void Awake()
    {
        value = 0;
        if (reverse)
            value = 1;
        rend = GetComponent<SpriteRenderer>();
        SetAlpha();
    }
    private void Update()
    {
        if (animate)
        {
            if(!reverse)
                value += Time.deltaTime * animSpeed;
            else
                value -= Time.deltaTime * animSpeed;
            SetAlpha();
            if (!reverse && value > 1)
                animate = false;
            if (reverse && value <0)
                animate = false;
        }
    }

    public void AnimateAlpha()
    {
        animate = true;
    }
    void SetAlpha()
    {
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, value);
    }
}
