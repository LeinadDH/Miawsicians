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
}
