/*
 This script is used exclusively for loading scenes. 
 Static functions are bound to levels in the game, and non-static functions allow the calling of them by integers or strings.
 */

 //Required libraries.
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    //FUNCTION:
    //CALLED BY:
    private static void LoadMenu()
    {
        SceneManager.LoadScene(StaticVariables.MenuSceneIndex);
    }

    //FUNCTION:
    //CALLED BY:
    private static void LoadLevel()
    {
        SceneManager.LoadScene(StaticVariables.LevelSceneIndex);
    }

    //FUNCTION:
    //CALLED BY:
    private static void QuitGame()
    {
        Application.Quit();
    }

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
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

    //FUNCTION:
    //CALLED BY:
    //INPUTS:
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
