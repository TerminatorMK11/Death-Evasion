using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(9);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(6);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene(8);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}