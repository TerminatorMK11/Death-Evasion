using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Samic OG")
        {
            SceneManager.LoadScene(7);
        }

        if(collision.tag == "Samic")
        {
            SceneManager.LoadScene(8);
        }
        if(collision.tag == "Samic LW")
        {
            SceneManager.LoadScene(9);
        }
        if(collision.tag == "Backrooms Samic")
        {
            SceneManager.LoadScene(10);
        }
        if(collision.tag == "Final Samic")
        {
            SceneManager.LoadScene(11);
        }
        if (collision.tag == "Super Samic")
        {
            SceneManager.LoadScene(14);
        }
    }
}