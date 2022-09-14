using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class MusicDowloand : MonoBehaviour
{
    public void btnDownload_Click()
    {
        WebClient webClient = new WebClient();
        //webClient.DownloadFileAsync(new Uri("https://bitmidi.com/uploads/28048.mid"), @"C:\Users\4\Downloads\Borrar\Miawsicians\Miawsician\Assets\StreamingAssets\MoonLight_Sonata.mid");
        //webClient.DownloadFileAsync(new Uri("https://bitmidi.com/uploads/28048.mid"), @Application.persistentDataPath + "/sonata_no_14_claro_de_luna.mid");
        webClient.DownloadFile(new Uri("https://bitmidi.com/uploads/28048.mid"), @Application.persistentDataPath + "/sonata_no_14_claro_de_luna.mid");
        Debug.Log("Complete");
        Debug.Log(Application.persistentDataPath);
    }

}
