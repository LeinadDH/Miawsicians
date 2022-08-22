using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keytoPress;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keytoPress))
        {
            Onpressed();
        }
        if(Input.GetKeyUp(keytoPress))
        {
            OnDrop();
        }
    }

    public void Onpressed()
    {
        theSR.sprite = pressedImage;
    }

    public void OnDrop()
    {
        theSR.sprite = defaultImage;
    }
}
