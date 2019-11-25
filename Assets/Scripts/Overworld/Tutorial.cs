using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Glenn glenn;
    public GameObject Tutorial01, Tutorial02;
    public GameObject Fecha01, Fecha02;
    private bool tutorialAtivo = false;
    public static bool fechei01 = false, fechei02 = false;

    public bool TutorialAtivo
    {
        get
        {
            return tutorialAtivo;
        }
        set
        {
            tutorialAtivo = value;
            glenn.possoAndar = !tutorialAtivo;
        }
    }
    private void Awake()
    {
        glenn = FindObjectOfType<Glenn>();
    }
    void Update()
    {
        if (glenn.transform.position.x >= -6.9 && !fechei01)
        {
            Tutorial01.SetActive(true);
            TutorialAtivo = true;
        }

        //Por algum motivo ele tenque ativar o tutorial 2 primeiro que o 1
        //arrumei kkk??? coloquei o -6.9 lá em cima e o 8 aqui embaixo(estava ao contrário)
        if (glenn.transform.position.x >= 8 && !fechei02)
        {
            Tutorial02.SetActive(true);
            TutorialAtivo = true;
        }
    }

    public void FechaPrimeiro()
    {
        fechei01 = true;
        TutorialAtivo = false;
        Destroy(Tutorial01);
    }

    public void FechaSegundo()
    {
        fechei02 = true;
        TutorialAtivo = false;
        Destroy(Tutorial02);
    }
}