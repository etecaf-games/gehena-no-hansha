using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Monstros: MonoBehaviour
{
    public string cenacarregar;
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            SceneManager.LoadScene(cenacarregar);
           
        }
    }
}
