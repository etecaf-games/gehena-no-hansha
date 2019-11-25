using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{

    public GameObject ImageCreditos;
    public float EixoY;
    public float velocidade = 10f;
    public float limiteY;

    public GameObject btnSair, btnMenu;
    public GameObject painelTextos;
    public bool destruido = false;

    public void FixedUpdate()
    {
        if (!destruido)
        {
            EixoY = ImageCreditos.transform.position.y;

            ImageCreditos.transform.position = new Vector3(ImageCreditos.transform.position.x, ImageCreditos.transform.position.y + velocidade, ImageCreditos.transform.position.z);

            if (EixoY > limiteY)
            {
                Destroy(ImageCreditos);
                destruido = true;
            }
        }
    }

    public void Update()
    {
        if (destruido)
        {
            painelTextos.SetActive(true);
        }
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
