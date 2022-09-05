using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string ScenetoLoad;
    public AudioSource audioSource;
    public GameObject canvas;

    public void TryAgain()
    {
        SceneManager.LoadScene(ScenetoLoad);
    }

    public void Continue()
    {
        audioSource.Play();
        canvas.SetActive(false);
        
    }
}
