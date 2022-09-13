using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScreen : MonoBehaviour
{
    public string menu, characters, credits;

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void CharactersScreen()
    {
        SceneManager.LoadScene(characters);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(credits);
    }
}
