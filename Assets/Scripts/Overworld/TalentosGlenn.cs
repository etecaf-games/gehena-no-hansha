﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentosGlenn : MonoBehaviour
{
    public Glenn glenn;
    public GameObject BotaoCompra1, BotaoCompra2;
    public GameObject menuPause;
    public GameObject painelTalentos;
    public Text valorSXP;

    public GameObject AtivadorGlenn, AtivadorThiess;
    public GameObject PainelGlenn, PainelThiess;
    public bool possoAtivar = true, possoAtivarThiess = true;
    public GameObject textFurtivo, textConfiavel, textAgil;
    public bool descFurtivo = false, descConfiavel = false, descAgil = false;
    public Thiess thiess;
    public GameObject BotaoCompra3, BotaoCompra4;
    public GameObject textVigoroso, textExplosivo, textCombat;
    public bool descVigoroso = false, descExploviso = false, descCombat = false;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void CompraConfiavel()
    {
        if (GlobalControl.Instance.XpGlenn >= 50)
        {
            GlobalControl.Instance.XpGlenn -= 50;
            GlobalControl.Instance.rangeHanzo += 1;
            GlobalControl.Instance.confiavel = true;
            AtualizaXP();

            if (GlobalControl.Instance.confiavel == true)
            {
                Destroy(BotaoCompra1);
            }
        }
    }

    public void CompraAgil()
    {
        if (GlobalControl.Instance.XpGlenn >= 50)
        {
            GlobalControl.Instance.XpGlenn -= 50;
            GlobalControl.Instance.agil = true;
            AtualizaXP();

            if (GlobalControl.Instance.agil == true)
            {
                Destroy(BotaoCompra2);
            }

        }
    }
    //mudar as coisas do thiess, que ta com as coisas do glenn *
    public void CompraExplosivo()
    {
        if (GlobalControl.Instance.XpThiess >= 50)
        {
            GlobalControl.Instance.XpThiess -= 50;
            GlobalControl.Instance.explosivo = true;
            AtualizaXP();

            if (GlobalControl.Instance.explosivo == true)
            {
                Destroy(BotaoCompra3);
            }

        }
    }

    public void CompraCombat()
    {
        if (GlobalControl.Instance.XpThiess >= 50)
        {
            GlobalControl.Instance.XpThiess -= 50;
            GlobalControl.Instance.combatente = true;
            AtualizaXP();

            if (GlobalControl.Instance.combatente == true)
            {
                Destroy(BotaoCompra4);
            }

        }
    }
    //ate aqui as habilidades do thiess *

    public void AtivadorPainel()
    {
        if (possoAtivar)
        {
            PainelGlenn.SetActive(true);
            PainelThiess.SetActive(false);
            possoAtivar = false;
        }
        else
        {
            PainelGlenn.SetActive(false);
            possoAtivar = true;
        }
    }

    public void AtivadorPainelThiess()
    {
        if (possoAtivarThiess)
        {
            PainelThiess.SetActive(true);
            PainelGlenn.SetActive(false);
            possoAtivarThiess = false;
        }
        else
        {
            PainelThiess.SetActive(false);
            possoAtivarThiess = true;
        }
    }

    public void DescricaoFurtivo()
    {
        if (descFurtivo)
        {
            textFurtivo.SetActive(true);
            descFurtivo = false;
        }
        else
        {
            textFurtivo.SetActive(false);
            descFurtivo = true;
        }
    }

    public void DescricaoConfiavel()
    {
        if (descConfiavel)
        {
            textConfiavel.SetActive(true);
            descConfiavel = false;
        }
        else
        {
            textConfiavel.SetActive(false);
            descConfiavel = true;
        }
    }

    public void DescricaoAgil()
    {
        if (descAgil)
        {
            textAgil.SetActive(true);
            descAgil = false;
        }
        else
        {
            textAgil.SetActive(false);
            descAgil = true;
        }
    }

    //começa textos thiess
    public void DescricaoVigoroso()
    {
        if (descVigoroso)
        {
            textVigoroso.SetActive(true);
            descVigoroso = false;
        }
        else
        {
            textVigoroso.SetActive(false);
            descVigoroso = true;
        }
    }

    public void DescricaoExploviso()
    {
        if (descExploviso)
        {
            textExplosivo.SetActive(true);
            descExploviso = false;
        }
        else
        {
            textExplosivo.SetActive(false);
            descExploviso = true;
        }
    }

    public void DescricaoCombat()
    {
        if (descCombat)
        {
            textCombat.SetActive(true);
            descCombat = false;
        }
        else
        {
            textCombat.SetActive(false);
            descCombat = true;
        }
    }

    //termina textos thiess

    public void ExitTalentos()
    {
        painelTalentos.SetActive(false);
        menuPause.SetActive(true);
    }

    public void AtualizaXP()
    {
        valorSXP.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
    }
}
