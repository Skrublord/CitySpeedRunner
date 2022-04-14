using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
    //load level scene
    public void PlayGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(1);
    }

    //quit
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
