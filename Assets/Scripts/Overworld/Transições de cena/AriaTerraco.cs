using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AriaTerraco : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            Player.possoPausar = false;
            SceneManager.LoadScene("TerraceCombat");
            GlobalControl.Instance.comecouLutaTerraco = true;

        }
    }
}
