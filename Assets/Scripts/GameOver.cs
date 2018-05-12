using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            gameOver.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        gameOver.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        gameOver.SetActive(false);
    }
}
