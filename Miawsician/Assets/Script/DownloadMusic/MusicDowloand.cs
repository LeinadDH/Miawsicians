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
    public GameObject NeedInternet;

    public void Button()
    {
        StartCoroutine(DownloadMinuetto());
        DownloadCanvas.SetActive(true);
        NeedInternet.SetActive(true);
    }

    IEnumerator DownloadMinuetto()
    {
        var uwr = new UnityWebRequest("http://www.piano-midi.de/midis/beethoven/beethoven_opus22_3.mid", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Minuetto.mid");
        uwr.downloadHandler = new DownloadHandlerFile(path); 
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success) Debug.LogError(uwr.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path);
            StartCoroutine(DownloadBee());
        }

    }

    IEnumerator DownloadBee()
    {
        var uwr = new UnityWebRequest("https://bitmidi.com/uploads/30544.mid", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Bee.mid");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success) Debug.LogError(uwr.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path);
            StartCoroutine(DownloadFantasie());
        }     
    }

    IEnumerator DownloadFantasie()
    {
        var uwr = new UnityWebRequest("https://bitmidi.com/uploads/30544.mid", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Fantasie.mid");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success) Debug.LogError(uwr.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path);
            StartCoroutine(DownloadLake());
        }
    }

    IEnumerator DownloadLake()
    {
        var uwr = new UnityWebRequest("https://bitmidi.com/uploads/103013.mid", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, "Lake.mid");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        downloadProgress = uwr.downloadProgress * -1;
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success) Debug.LogError(uwr.error);
        else
        {
            Debug.Log("File successfully downloaded and saved to " + path);
        }
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            NeedInternet.SetActive(true);
        }
        else
        {
            NeedInternet.SetActive(false);

            text.text = "Download Music: " + downloadProgress;
            if (downloadProgress == 1)
            {
                DownloadCanvas.SetActive(false);
            }

            string file0 = Path.Combine(Application.persistentDataPath, "Minuetto.mid");
            string file1 = Path.Combine(Application.persistentDataPath, "Bee.mid");
            string file2 = Path.Combine(Application.persistentDataPath, "fantasie.mid");
            string file3 = Path.Combine(Application.persistentDataPath, "Lake.mid");
            string file4 = Path.Combine(Application.persistentDataPath, "Minuetto.mid");

            if (File.Exists(file0) && File.Exists(file1) && File.Exists(file2) && File.Exists(file3)) 
            {
                DownloadCanvas.SetActive(false);
            }
        }
        
    }
}
