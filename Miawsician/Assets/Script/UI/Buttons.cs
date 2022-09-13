using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public bool isPressed;

    public Animator animator;
    public string AnimatorBool;

    void Start()
    {
        button = GetComponent<Button>();
        isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = pressedImage;
        isPressed = true;
        animator.SetBool(AnimatorBool, true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = defaultImage;
        isPressed = false;
        animator.SetBool(AnimatorBool, false);
    }
}
