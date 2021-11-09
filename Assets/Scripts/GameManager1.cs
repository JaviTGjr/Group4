using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    public static bool gameIsOver = false;

    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
            return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }


    void EndGame()
    {
        gameIsOver = true;
        Debug.Log("Game over!");
        gameOverUI.SetActive(true);
    }
}
