using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class MusicDowloand : MonoBehaviour
{
    public float downloadProgress;
    public TMP_Text text;
    public GameObject DownloadCanvas;

    public void Button()
    {
        StartCoroutine(DownloadFile());
        Debug.Log(Application.persistentDataPath);
        DownloadCanvas.SetActive(true);
    }

    IEnumerator DownloadFile()
    {
        var uwr = new UnityWebRequest("http://www.piano-midi.de/midis/beethoven/beethoven_opus22_3.mid", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Minuetto.mid");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        downloadProgress = uwr.downloadProgress * -1;    
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }

    private void Update()
    {
        Debug.Log(downloadProgress);
        text.text = "Download Music: " + downloadProgress;
        if (downloadProgress == 1)
        {
            DownloadCanvas.SetActive(false);
        }

        string file = Path.Combine(Application.persistentDataPath, "Minuetto.mid");
        if (File.Exists(file))
        {
            DownloadCanvas.SetActive(false);
        }
    }
}
