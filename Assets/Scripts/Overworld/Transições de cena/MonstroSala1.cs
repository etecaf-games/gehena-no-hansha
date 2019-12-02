using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonstroSala1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            Player.possoPausar = false;
            SceneManager.LoadScene("ClassroomCombat1");
            GlobalControl.Instance.comecouLutaSala1 = true;

        }
    }
}
