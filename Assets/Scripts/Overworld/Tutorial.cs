using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //private Glenn glenn;
    private Player player;
    public GameObject Tutorial01, Tutorial02,TutorialMov;
    public GameObject Fecha01, Fecha02,FechaMov;
    private bool tutorialAtivo = false;
    public bool fechei01 = false, fechei02 = false, fecheiMov = false;

    public bool TutorialAtivo
    {
        get
        {
            return tutorialAtivo;
        }
        set
        {
            tutorialAtivo = value;
            Player.possoAndar = !tutorialAtivo;
        }
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (player.transform.position.x >= -6.9 && !fechei01 && GlobalControl.Instance.tutorial01 == false)
        {
            Tutorial01.SetActive(true);
            GlobalControl.Instance.tutorial01 = true;
            TutorialAtivo = true;
        }

        //Por algum motivo ele tenque ativar o tutorial 2 primeiro que o 1
        //arrumei kkk??? coloquei o -6.9 lá em cima e o 8 aqui embaixo(estava ao contrário)
        if (player.transform.position.x >= 8 && !fechei02 && GlobalControl.Instance.tutorial02 == false)
        {
            Tutorial02.SetActive(true);
            GlobalControl.Instance.tutorial02 = true;
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

    public void FechaMovi()
    {
        fecheiMov = true;
        TutorialAtivo = false;
        Destroy(TutorialMov);
    }
}