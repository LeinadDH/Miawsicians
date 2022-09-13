using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string ScenetoLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(ScenetoLoad);
    }
}
