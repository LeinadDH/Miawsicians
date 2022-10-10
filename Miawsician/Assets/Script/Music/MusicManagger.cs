using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;

public class MusicManagger : MonoBehaviour
{
    public Timer timer;
    public static MusicManagger Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public double marginOfError;

    public int inputDelayInMilisenconds;

    public string fileName;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;

    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;
    void Start()
    {
        Instance = this;
        ReadFromFile();
    }

    private void ReadFromFile()
    {
        Debug.Log(Application.persistentDataPath);
        midiFile = MidiFile.Read(Application.persistentDataPath + "/" + fileName);
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }
}
