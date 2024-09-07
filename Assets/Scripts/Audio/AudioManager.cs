using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance { get; private set; }

    private EventInstance ambienceEventInstance;
    private List<EventInstance> eventInstances;

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.LogError("Found more than one AudioManager");
        }
        
        instance = this;

        eventInstances = new List<EventInstance>();
    }

    private void InitAmbience(EventReference ambienceEventRef)
    {
        ambienceEventInstance = CreateInstance(ambienceEventRef);
        ambienceEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    private void Start()
    {
        InitAmbience(FmodEvents.instance.pondSound);
    }

    public EventInstance CreateInstance(EventReference eventReference) 
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
}
