using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void loadScene(string name)
    {
        Debug.Log(name);
        SceneManager.LoadScene(name);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
