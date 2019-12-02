using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassandoCoisas : MonoBehaviour
{
    //public GameObject VoltaPerso;
    public GameObject Botao, voltacoisas;

    [Header("Personagem")]
    public GameObject TudoPerso,PersoIntera, PersoMovimento, troca;

    [Header("Monstrons")]
    public GameObject Monstrons;

    [Header("Combate")]
    public GameObject GrupodeImagensCombate;
    public GameObject Image01, Image02, Image03, Image04, Image05, Image06, Image07, Image08;

    [Header("SXP")]
    public GameObject Sxp;

    public void Volta()
    {
        Botao.SetActive(true);
        voltacoisas.SetActive(false);

        TudoPerso.SetActive(false);
        Monstrons.SetActive(false);
        GrupodeImagensCombate.SetActive(false);
        Sxp.SetActive(false);
    }

    public void AtivaMonstrons()
    {
        voltacoisas.SetActive(true);
        Monstrons.SetActive(true);
    }

    public void Ativa01()
    {
        voltacoisas.SetActive(true);
        Image01.SetActive(true);
        Image02.SetActive(false);
    }

    public void Ativa02()
    {
        voltacoisas.SetActive(true);
        Image01.SetActive(false);
        Image02.SetActive(true);
        Image03.SetActive(false);
    }

    public void Ativa03()
    {
        voltacoisas.SetActive(true);
        Image02.SetActive(false);
        Image03.SetActive(true);
        Image04.SetActive(false);
    }

    public void Ativa04()
    {
        voltacoisas.SetActive(true);
        Image03.SetActive(false);
        Image04.SetActive(true);
        Image05.SetActive(false);
    }

    public void Ativa05()
    {
        voltacoisas.SetActive(true);
        Image04.SetActive(false);
        Image05.SetActive(true);
        Image06.SetActive(false);
    }

    public void Ativa06()
    {
        voltacoisas.SetActive(true);
        Image05.SetActive(false);
        Image06.SetActive(true);
        Image07.SetActive(false);
    }

    public void Ativa07()
    {
        voltacoisas.SetActive(true);
        Image06.SetActive(false);
        Image07.SetActive(true);
        Image08.SetActive(false);
    }

    public void Ativa08()
    {
        voltacoisas.SetActive(true);
        Image07.SetActive(false);
        Image08.SetActive(true);
    }

    public void AtivaSxp()
    {
        voltacoisas.SetActive(true);
        Sxp.SetActive(true);
    }


    public void AtivaCombate()
    {
        voltacoisas.SetActive(true);
        Image01.SetActive(true);
    }

    public void AtivaMovimento()
    {
        voltacoisas.SetActive(true);
        troca.SetActive(false);
        PersoIntera.SetActive(false);
        PersoMovimento.SetActive(true);
    }

    public void AtivaIntera()
    {
        voltacoisas.SetActive(true);
        troca.SetActive(false);
        PersoIntera.SetActive(true);
        PersoMovimento.SetActive(false);
    }

    public void AtivaTroca()
    {
        voltacoisas.SetActive(true);
        troca.SetActive(true);
        PersoIntera.SetActive(false);
        PersoMovimento.SetActive(false);
    }



}
