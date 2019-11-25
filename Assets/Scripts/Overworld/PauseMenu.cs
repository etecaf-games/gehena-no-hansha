using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject painelTalentos;
    public Image menuEquips;
    public GameObject menuPause, canvas, gameMaster;
    public GameObject tooltip, painelSlots, botaoVoltar, painelStatus;
    //public Image inventario;
    //public GameObject painel,slot;
    //public Glenn glenn;
    //public HanzoTeste Hanzo;
    public Text valorSXP;
    public Text valorSXP2, ValorHp, ValorSp, ValorMove, ValorAp, ValorAtk, ValorFor, ValorDef, ValorRes, ValorAgi, ValorVit, ValorEsp, ValorMag;
    public Inventory inventory;
    public void Talentos()
    {
        Debug.Log(GlobalControl.Instance.XpGlenn);
        valorSXP.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
        painelTalentos.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Inventario()
    {

        menuEquips.enabled = true;
        painelSlots.SetActive(true);
        botaoVoltar.SetActive(true);
        //inventario.enabled = true;
        //painel.SetActive(true);
        //slot.SetActive(true);
        tooltip.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Status()
    {
        valorSXP2.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
        ValorAtk.text = "Ataque: " + GlobalControl.Instance.attackHanzo.ToString();
        ValorDef.text = "Defesa: " + GlobalControl.Instance.defenseHanzo.ToString();
        ValorFor.text = "Força: " + GlobalControl.Instance.strengthHanzo.ToString();
        ValorRes.text = "Resistência: " + GlobalControl.Instance.resistanceHanzo.ToString();
        ValorAgi.text = "Agilidade: " + GlobalControl.Instance.agilityHanzo.ToString();
        ValorVit.text = "Vitalidade: " + GlobalControl.Instance.vitalityHanzo.ToString();
        ValorEsp.text = "Espírito: " + GlobalControl.Instance.spiritHanzo.ToString();
        ValorMag.text = "Magia: " + GlobalControl.Instance.magicHanzo.ToString();
        ValorHp.text = "HP Base: " + GlobalControl.Instance.HPBaseHanzo.ToString();
        ValorSp.text = "SP Base: " + GlobalControl.Instance.SPBaseHanzo.ToString();
        ValorMove.text = "Move: " + GlobalControl.Instance.moveHanzo.ToString();
        ValorAp.text = "PA: " + GlobalControl.Instance.actionPointsHanzo.ToString();
        painelStatus.SetActive(true);
        menuPause.SetActive(false);
    }

    //public void Status()
    //{
    //    valorSXP.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
    //    ValorAtk.text = "Ataque: " + GlobalControl.Instance.attackHanzo.ToString();
    //    ValorDef.text = "Defesa: " + GlobalControl.Instance.defenseHanzo.ToString();
    //    ValorFor.text = "Força: " + GlobalControl.Instance.strengthHanzo.ToString();
    //    ValorRes.text = "Resistência: " + GlobalControl.Instance.resistanceHanzo.ToString();
    //    ValorAgi.text = "Agilidade: " + GlobalControl.Instance.agilityHanzo.ToString();
    //    ValorVit.text = "Vitalidade: " + GlobalControl.Instance.vitalityHanzo.ToString();
    //    ValorEsp.text = "Espírito: " + GlobalControl.Instance.spiritHanzo.ToString();
    //    ValorMag.text = "Magia: " + GlobalControl.Instance.magicHanzo.ToString();
    //    ValorHp.text = "HP Base: " + GlobalControl.Instance.HPBaseHanzo.ToString();
    //    ValorSp.text = "SP Base: " + GlobalControl.Instance.SPBaseHanzo.ToString();
    //    ValorMove.text = "Move: " + GlobalControl.Instance.moveHanzo.ToString();
    //    ValorAp.text = "PA: " + GlobalControl.Instance.actionPointsHanzo.ToString();
    //    painelStatus.SetActive(true);
    //    menuPause.SetActive(false);
    //}

    public void VoltaMenu()
    {
        Destroy(FindObjectOfType<GlobalControl>());
        Destroy(FindObjectOfType<Canvas>());
        SceneManager.LoadScene("Menu");
        GlobalControl.Instance.comecouJogo = false;
    }
}
