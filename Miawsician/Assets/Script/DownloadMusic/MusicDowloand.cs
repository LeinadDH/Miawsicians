using System;
using System.ComponentModel;
using System.Net;
using UnityEngine;


public class MusicDowloand : MonoBehaviour
{
    public void btnDownload_Click()
    {    
        WebClient webClient = new WebClient();
        webClient.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Downloader_DownloadProgressChanged);
        //webClient.DownloadFileAsync(new Uri("http://www.musicamidigratis.com/midis/38/descargar.html"), @Application.streamingAssetsPath + "/sonata_no_14_claro_de_luna.mid");
        webClient.DownloadFileAsync(new Uri("http://www.musicamidigratis.com/midis/38/descargar.html"), @Application.persistentDataPath + "/sonata_no_14_claro_de_luna.mid");
        while (webClient.IsBusy) 
        {
            Debug.Log("Complete");
            Debug.Log(Application.persistentDataPath);
        }
    }

    private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        // print progress of download.
        Console.WriteLine(e.BytesReceived + " " + e.ProgressPercentage);
    }

    private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        // display completion status.
        if (e.Error != null)
            Console.WriteLine(e.Error.Message);
        else
            Console.WriteLine("Download Completed!!!");
    }
}
