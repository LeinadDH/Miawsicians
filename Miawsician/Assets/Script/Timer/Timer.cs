using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject ASObject;
    public int seconds;
    private int s;
    public GameObject timerCanvas;

    [SerializeField]
    private TMP_Text timerText;

    void Start()
    {
        seconds = 3;
    }

    public void StartTime()
    {
        s = seconds;
        WriteTimer(s);
        StartCoroutine(UpdateTimer());
    }

    public void StopTimer()
    {
        StopCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        yield return new WaitForSeconds(1);
        if(s == 0)
        {
            ASObject.SetActive(true);
            timerCanvas.SetActive(false);
            audioSource.Play();
            StopTimer();
        }
        else
        {
            s--;
            WriteTimer(s);
            StartCoroutine(UpdateTimer());
        }
    }

    private void WriteTimer(int sec)
    {
        timerText.text = sec.ToString();
    }
}
