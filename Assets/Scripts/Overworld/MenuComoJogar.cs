using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuComoJogar : MonoBehaviour
{
    public GameObject Botoes;
    public GameObject voltar;
    public GameObject Personagem,monstros,combate,sxp;

    public PassandoCoisas passandoCoisas;
    public GameObject PainelComojogar,pause;

   public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }

    public void voltandomenupause()
    {
        pause.SetActive(true);
        PainelComojogar.SetActive(false);
    }
    public void voltaAqui()
    {
        Botoes.SetActive(true);
        voltar.SetActive(false);

        Personagem.SetActive(false);
        monstros.SetActive(false);
        combate.SetActive(false);
        sxp.SetActive(false);
    }

    public void AtivaPersonagem()
    {
        Personagem.SetActive(true);
        voltar.SetActive(true);

        Botoes.SetActive(false);
        passandoCoisas.voltacoisas.SetActive(true);
    }

    public void AtivaMonstros()
    {
        monstros.SetActive(true);

        voltar.SetActive(true);
        Botoes.SetActive(false);
        passandoCoisas.voltacoisas.SetActive(true);
    }

    public void AtivaCombate()
    {
        combate.SetActive(true);

        voltar.SetActive(true);
        Botoes.SetActive(false);
        passandoCoisas.voltacoisas.SetActive(true);
    }

    public void AtivaSxp()
    {
        sxp.SetActive(true);

        voltar.SetActive(true);
        Botoes.SetActive(false);
        passandoCoisas.voltacoisas.SetActive(true);
    }
}
