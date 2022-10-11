using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar, leftButton, rightButton;
    public float scrollPos = 0;
    public float[] pos;

    private int index = 0;

    void Start()
    {
        scrollPos = 0;
        UpdateButtons();
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if(Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < pos.Length; i++)
            {
                if(scrollPos < pos[i] + (distance/2) && scrollPos > pos[i] - (distance/2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i) 
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    public void LeftButton()
    {
        float i = scrollPos;
        index--;
        if (scrollPos > 0 && scrollPos == i)
        {
            scrollPos = scrollPos - 0.2f;
        }
        UpdateButtons();
    }

    public void RightButton()
    {
        float i = scrollPos;
        index++;
        if (scrollPos < pos.Length && scrollPos == i)
        {
            scrollPos = i + 0.2f;
        }
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if (index == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }

        if (index == 3)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }



}
