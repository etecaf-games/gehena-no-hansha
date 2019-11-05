using System.Collections;
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

    public void CompraConfiavel()
    {
        if (glenn.SocialXp >= 50)
        {
            glenn.SocialXp -= 50;
            glenn.confiavel = true;
            Destroy(BotaoCompra1);
            AtualizaXP();


        }
    }
        public void CompraAgil()
    { 
        if(glenn.SocialXp>= 50)
    {
        glenn.SocialXp -= 50;
        glenn.agil = true;
        Destroy(BotaoCompra2);
        AtualizaXP();

    }


    }

        public void ExitTalentos()
        {
            painelTalentos.SetActive(false);
            menuPause.SetActive(true);
        }

        public void AtualizaXP()
        {
            valorSXP.text = "SXP: " + glenn.SocialXp.ToString();
        }
 
}
