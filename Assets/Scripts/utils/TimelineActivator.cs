using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using ScriptableObjectArchitecture;
public class TimelineActivator : MonoBehaviour
{
    [SerializeField]
    GameEvent nextlevel;
    PlayableDirector timeline;
    public bool nextLvl = false;
    bool raised = false;

    private void Awake()
    {
        raised = false;
        nextLvl = false;
        timeline = GetComponent<PlayableDirector>();
    }
    private void Update()
    {
        if (!raised && nextLvl)
        {
            nextlevel.Raise();
            raised = true;
        }
    }
    public void InitiateTimeline()
    {
        timeline.Play();
    }

}
