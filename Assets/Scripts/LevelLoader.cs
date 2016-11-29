/*
 This script is used exclusively for loading scenes. 
 Static functions are bound to levels in the game, and non-static functions allow the calling of them by integers or strings.
 */

 //Required libraries.
using UnityEngine;
using UnityEngine.SceneManagement;

//Class that contains all loading scripts.
public class LevelLoader : MonoBehaviour {

    //FUNCTION: Loads the menu screen
    //CALLED BY: ButtonLoad function
    private static void LoadMenu()
    {
        SceneManager.LoadScene(StaticVariables.MenuSceneIndex);
    }

    //FUNCTION: Loads the level
    //CALLED BY: ButtonLoad function
    private static void LoadLevel()
    {
        SceneManager.LoadScene(StaticVariables.LevelSceneIndex);
    }

    //FUNCTION: Quits the game
    //CALLED BY: ButtonLoad function
    private static void QuitGame()
    {
        Application.Quit();
    }

    //FUNCTION: Reloads level
    //CALLED BY: Anything function to reload, like player when it dies.
    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //FUNCTION: Decides which scene to load based on parameters given.
    //CALLED BY: Any object with a reference that wants to change the scene.
    //INPUTS: Integer for the scene, -1 if calling to quit the game.
    public void ButtonLoad(int _scene)
    {
        //Switch statement decides which scene to load.
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

    //FUNCTION: Decides which scene to load based on parameters given. Overloaded version of above, this time for integers.
    //CALLED BY: Any object with a reference that wants to change the scene.
    //INPUTS: String for the scene, -1 if calling to quit the game.
    public void ButtonLoad(string _scene)
    {
        //Switch statement decides which scene to load.
        //Several options are available for each function, QUIT and EXIT both will end the game.
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
