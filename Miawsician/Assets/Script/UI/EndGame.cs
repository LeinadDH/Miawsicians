using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public string ScenetoLoad, MenuScene;
    public AudioSource audioSource;
    public GameObject LostCanvas, PauseCanvas, LoadinCanvas, timerCanvas, ASObject;
    private bool pause = false;

    private Timer timer;

    private void Start()
    {
        ASObject.SetActive(false);
        timer = gameObject.GetComponent<Timer>();
        LostCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        LoadinCanvas.SetActive(false);
        timerCanvas.SetActive(true);
        timer.StartTime();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && !pause && ASObject.activeInHierarchy)
        {
            SceneManager.LoadScene(MenuScene);
        }
    }

    public void Continue()
    {
        timer.StartTime();
        timerCanvas.SetActive(true);
        LostCanvas.SetActive(false);    
        PauseCanvas.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void Pause()
    {
        pause = true;
        PauseCanvas.SetActive(true);
        audioSource.Pause();
    }
}
