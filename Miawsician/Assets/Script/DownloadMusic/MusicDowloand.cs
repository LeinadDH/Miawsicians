using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;

public class MusicDowloand : MonoBehaviour
{
    public GameObject Canvas;

    private void Start()
    {
        Canvas.SetActive(true);
    }

    public void btnDownload_Click()
    {    
        WebClient webClient = new WebClient();
        webClient.DownloadFileAsync(new Uri("http://www.musicamidigratis.com/midis/38/descargar.html"), @Application.streamingAssetsPath + "/testeoDos.mid");
        //webClient.DownloadFileAsync(new Uri("http://www.musicamidigratis.com/midis/38/descargar.html"), @Application.persistentDataPath + "/sonata_no_14_claro_de_luna.mid");
        Debug.Log("Complete");
        Debug.Log(Application.persistentDataPath);
    }

    public void DownloadFile()
    {
        WebClient client = new WebClient();
        client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
        client.DownloadFile(new Uri("http://www.musicamidigratis.com/midis/38/descargar.html"), @Application.streamingAssetsPath  + "/TesteoTres.mid");
    }

    void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            Canvas.SetActive(false);
        }
    }
}
