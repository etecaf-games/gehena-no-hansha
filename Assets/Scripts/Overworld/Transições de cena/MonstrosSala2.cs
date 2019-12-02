using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonstrosSala2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            Player.possoPausar = false;
            SceneManager.LoadScene("ClassroomCombat2");
            GlobalControl.Instance.comecouLutaSala2 = true;

        }
    }
}
