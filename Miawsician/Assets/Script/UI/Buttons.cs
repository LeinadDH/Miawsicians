using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool isPressed;

    void Start()
    {
        button = GetComponent<Button>();
        isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = pressedImage;
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = defaultImage;
        isPressed = false;
    }
}
