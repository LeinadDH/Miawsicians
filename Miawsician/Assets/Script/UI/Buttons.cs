using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    public Sprite defaultImage;
    public Sprite pressedImage;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = pressedImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = defaultImage;
    }
}
