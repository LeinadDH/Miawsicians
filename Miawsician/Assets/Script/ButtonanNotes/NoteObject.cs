using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteObject : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;
    Buttons buttons;
    public AudioSource audioSource;
    private bool canhold = false;

    private void Start()
    {
        audioSource.Play();
        buttons = button.GetComponent<Buttons>();
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (buttons.isPressed && !canhold)
        {
            buttons.isPressed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Note")
        {
            canhold = true;
            if (buttons.isPressed && canhold)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canhold = false;
    }
}
