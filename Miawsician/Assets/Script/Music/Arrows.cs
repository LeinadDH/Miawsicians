using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = MusicManagger.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstatiated = MusicManagger.GetAudioSourceTime() - timeInstantiated;
        float time = (float)(timeInstantiated / (MusicManagger.Instance.noteTime * 2)); 

        if(timeInstantiated > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * MusicManagger.Instance.noteSpawnY, Vector3.up * MusicManagger.Instance.noteSpawnY, time);
        }
    }
}
