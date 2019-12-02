using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Carregar : MonoBehaviour
{
    public bool podeInteragir = false;
    public GameObject Jogador;
    public string CenaACarregar;

    void Update()
    {
        if (podeInteragir == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(CenaACarregar);
            GlobalControl.entrouSala1 = true;
        }
    }

    void OnTriggerEnter2D()
    {
        podeInteragir = true;
    }

    void OnTriggerExit2D()
    {
        podeInteragir = false;
    }

    //void OnGUI()
    //{
    //    if (podeInteragir == true)
    //    {
    //        GUIStyle stylez = new GUIStyle();
    //        stylez.alignment = TextAnchor.MiddleCenter;
    //        GUI.skin.label.fontSize = 20;
    //        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 200, 30), "Pressione 'E'");
    //    }
    //}
}
