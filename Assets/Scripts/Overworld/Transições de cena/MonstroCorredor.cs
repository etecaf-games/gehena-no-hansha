using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonstroCorredor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            Player.possoPausar = false;
            SceneManager.LoadScene("CorridorCombat");
            GlobalControl.Instance.comecouLutaCorredor = true;

        }
    }
}
