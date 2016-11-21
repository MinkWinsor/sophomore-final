using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

	public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        print("Loaded scene: " + SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadGameLevel(int _levelToLoad)
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }


    //The following functions are for use by buttons, since buttons can't call static scripts. 
    //However, the static functions can be called just as easily.
    public void ButtonLoad(int _levelToLoad)
    {
        LoadGameLevel(_levelToLoad);
    }

    public void ButtonQuit()
    {
        QuitGame();
    }

    public void ButtonRestart()
    {
        ReloadCurrentScene();
    }
}
