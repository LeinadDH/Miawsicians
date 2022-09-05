using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;
    Buttons buttons;
    public bool canClick = false;
    public bool hold = false;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
        buttons = button.GetComponent<Buttons>();
        canvas.SetActive(false);
    }

    private void Update()
    {
        if(buttons.isPressed)
        {
            if (!canClick)
            {
                audioSource.Pause();
                canvas.SetActive(true);
            }
        }
        if (!hold && buttons.isPressed)
        {
            StartCoroutine(DontHoldTheButton());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Note")
        {
            hold = true;
            canClick = true;
            if (buttons.isPressed)
            {
                //ScoreManagger.Hit();
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hold = false;
    }

    IEnumerator DontHoldTheButton()
    {
        yield return new WaitForSeconds(2);
        canClick = false;
    }


}
