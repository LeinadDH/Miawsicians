using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen, PauseScreen, EndScreen;
    public Slider loadingFill;

    public void LoadScene(int sceneid)
    {
        StartCoroutine(LoadSceneAsync(sceneid));
    }

    IEnumerator LoadSceneAsync(int sceneid)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneid);

        PauseScreen.SetActive(false);
        EndScreen.SetActive(false);
        LoadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress/ 0.9f);

            loadingFill.value = progressValue;

            yield return null;
        }
    }
}
