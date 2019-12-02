using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortaSalaCorredor1 : MonoBehaviour
{
    public bool podeInteragir = false;
    void Update()
    {
        if (podeInteragir == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Corredor1");
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            podeInteragir = true;
            for (int i = 0; i < quem.transform.childCount; i++)
            {
                Transform filho = quem.transform.GetChild(i);
                if (filho.name == "exclamacao_v1")
                {
                    filho.gameObject.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            podeInteragir = false;
            for (int i = 0; i < quem.transform.childCount; i++)
            {
                Transform filho = quem.transform.GetChild(i);
                if (filho.name == "exclamacao_v1")
                {
                    filho.gameObject.SetActive(false);
                }
            }
        }
    }
}