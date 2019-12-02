using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscadasTerraço : MonoBehaviour
{
    public bool podeInteragir = false;
    public GameObject player;
    public Transform escada;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalControl.subiuTerraco == true)
        {
            player.transform.position = escada.position;
            GlobalControl.subiuTerraco = false;
        }
    }

    void Update()
    {
        if (podeInteragir == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Terrace");
            GlobalControl.entrouSala1 = true;
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
                    GameObject exclamacao = filho.gameObject;
                    exclamacao.SetActive(true);
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
                    GameObject exclamacao = filho.gameObject;
                    exclamacao.SetActive(false);
                }
            }
        }
    }
}
