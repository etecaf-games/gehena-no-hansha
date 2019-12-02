using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class creditos : MonoBehaviour
{

    public GameObject ImageCreditos;
    public float EixoY;
    public float velocidade = 10f;
    public float limiteY;

    public GameObject btnSair, btnMenu;
    public GameObject painelTextos;
    //public bool destruido = false;

    //public void FixedUpdate()
    //{
    //    if (!destruido)
    //    {
    //        EixoY = ImageCreditos.transform.position.y;

    //        ImageCreditos.transform.position = new Vector3(ImageCreditos.transform.position.x, ImageCreditos.transform.position.y + velocidade, ImageCreditos.transform.position.z);

    //        if (EixoY > limiteY)
    //        {

    //            destruido = true;
    //        }
    //    }
    //}

    //public void Update()
    //{
    //    if (destruido)
    //    {

    //    }
    //}
    public void LigaPainelTextos()
    {
        ImageCreditos.GetComponent<Image>().enabled = false;
        painelTextos.SetActive(true);
    }
    public void VaiProMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
