using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSong : MonoBehaviour
{
    public string levelOne;
    public string levelFour;

    public void LevelOne()
    {
        SceneManager.LoadScene(levelOne);
    }

    public void LevelFOur()
    {
        SceneManager.LoadScene(levelFour);
    }
}
