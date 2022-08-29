using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;

    void Start()
    {
        timeInstantiated = MusicManagger.GetAudioSourceTime();
    }

    void Update()
    {
        double timeSinceInstantiated = MusicManagger.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (MusicManagger.Instance.noteTime * 2));

        if(t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * MusicManagger.Instance.noteSpawnY, Vector3.up * MusicManagger.Instance.noteDespawnY, t);
        }
    }
}
