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
}
