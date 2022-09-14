using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject UI;

    private void Start()
    {
        UI.SetActive(true);
    }

    public void CloseDownload()
    {
        UI.SetActive(false);
    }
}
