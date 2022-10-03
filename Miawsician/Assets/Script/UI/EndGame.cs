using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string ScenetoLoad, MenuScene;
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

    public void Menu()
    {
        SceneManager.LoadScene(MenuScene);
    }

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            //StartCoroutine(BackMenu());
        }
    }

    IEnumerator BackMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(MenuScene);
        StopCoroutine(BackMenu());
    }
}
