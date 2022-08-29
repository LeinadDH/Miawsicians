using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps;

    int spawnIndex = 0;
    int inputIndex = 0;

    void Start()
    {
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach(var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, MusicManagger.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60 + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIndex < timeStamps.Count)
        {
            if (MusicManagger.GetAudioSourceTime() >= timeStamps[spawnIndex] - MusicManagger.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if(inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = MusicManagger.Instance.marginOfError;
            double audioTime = MusicManagger.GetAudioSourceTime() - (MusicManagger.Instance.inputDelayInMilisenconds / 1000.0);

            if(Input.GetKeyDown(input))
            {
                if(Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
                if(timeStamp + marginOfError <= audioTime)
                {
                    Miss();
                    print($"Missed {inputIndex} note");
                    inputIndex++;
                }
            }
        }
    }

    private void Hit()
    {
        ScoreManagger.Hit();
    }

    private void Miss()
    {
        ScoreManagger.Miss();
    }
}
