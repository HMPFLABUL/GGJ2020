using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    PlayableDirector timeline;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }
    public void InitiateTimeline()
    {
        timeline.Play();
    }
}
