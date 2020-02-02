using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class OffAtEvent : MonoBehaviour
{
    [SerializeField]
    GameEvent evnt;
    private void Awake()
    {
        evnt.AddListener(Off);
    }
    private void OnDestroy()
    {
        evnt.RemoveListener(Off);
    }

    public void Off()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
