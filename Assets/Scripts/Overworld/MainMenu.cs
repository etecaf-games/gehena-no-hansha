using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Corredor1");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void ComoJogar()
    {
        SceneManager.LoadScene("ComoJogar1");
    }
}
