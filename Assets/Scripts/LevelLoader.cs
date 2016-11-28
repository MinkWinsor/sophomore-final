using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public static void LoadMenu()
    {
        SceneManager.LoadScene(StaticVariables.MenuSceneIndex);
    }


    public static void LoadLevel()
    {
        SceneManager.LoadScene(StaticVariables.LevelSceneIndex);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    

    public void ButtonLoad(int _scene)
    {
        switch (_scene)
        {
            case -1:
                QuitGame();
                break;
            case 0:
                LoadMenu();
                break;
            case 1:
                LoadLevel();
                break;

        }
    }

    public void ButtonLoad(string _scene)
    {
        _scene.ToUpper();
        switch (_scene)
        {
            case "QUIT":
            case "EXIT":
            case "RAGE QUIT":
                QuitGame();
                break;
            case "MENU":
            case "START":
                LoadMenu();
                break;
            case "LEVEL":
            case "FIRST LEVEL":
            case "MAIN GAME":
                LoadLevel();
                break;
        }
    }
}
