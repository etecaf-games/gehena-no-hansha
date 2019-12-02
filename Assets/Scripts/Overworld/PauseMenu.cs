using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject painelTalentos;
    public GameObject painelComoJogar;
    public Image menuEquips;
    public GameObject menuPause, canvas, gameMaster;
    public GameObject tooltip, painelSlots, botaoVoltar, painelStatusHanzo, painelStatusFenrir, painelSkills;
    //public Image inventario;
    //public GameObject painel,slot;
    //public Glenn glenn;
    //public HanzoTeste Hanzo;
    public Text valorSXP, valorSXP4;
    public Text valorSXP2, ValorHp, ValorSp, ValorMove, ValorAp, ValorAtk, ValorFor, ValorDef, ValorRes, ValorAgi, ValorVit, ValorEsp, ValorMag;
    public Text valorSXP3, ValorHp2, ValorSp2, ValorMove2, ValorAp2, ValorAtk2, ValorFor2, ValorDef2, ValorRes2, ValorAgi2, ValorVit2, ValorEsp2, ValorMag2;
    public Inventory inventory;
    public void Talentos()
    {
        Debug.Log(GlobalControl.Instance.XpGlenn);
        valorSXP.text = "XP Glenn: " + GlobalControl.Instance.XpGlenn.ToString();
        valorSXP4.text = "XP Thiess: " + GlobalControl.Instance.XpThiess.ToString();
        painelTalentos.SetActive(true);
        menuPause.SetActive(false);
    }

    public void ComoJogar()
    {
        menuPause.SetActive(false);
        painelComoJogar.SetActive(true);
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

    public void StatusHanzo()
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
        painelStatusHanzo.SetActive(true);
        painelStatusFenrir.SetActive(false);
        menuPause.SetActive(false);
        painelSkills.SetActive(false);
    }

    public void StatusFenrir()
    {

        valorSXP3.text = "XP: " + GlobalControl.Instance.XpThiess.ToString();
        ValorAtk2.text = "Ataque: " + GlobalControl.Instance.attackFenrir.ToString();
        ValorDef2.text = "Defesa: " + GlobalControl.Instance.defenseFenrir.ToString();
        ValorFor2.text = "Força: " + GlobalControl.Instance.strengthFenrir.ToString();
        ValorRes2.text = "Resistência: " + GlobalControl.Instance.resistanceFenrir.ToString();
        ValorAgi2.text = "Agilidade: " + GlobalControl.Instance.agilityFenrir.ToString();
        ValorVit2.text = "Vitalidade: " + GlobalControl.Instance.vitalityFenrir.ToString();
        ValorEsp2.text = "Espírito: " + GlobalControl.Instance.spiritFenrir.ToString();
        ValorMag2.text = "Magia: " + GlobalControl.Instance.magicFenrir.ToString();
        ValorHp2.text = "HP Base: " + GlobalControl.Instance.HPBaseFenrir.ToString();
        ValorSp2.text = "SP Base: " + GlobalControl.Instance.SPBaseFenrir.ToString();
        ValorMove2.text = "Move: " + GlobalControl.Instance.moveFenrir.ToString();
        ValorAp2.text = "PA: " + GlobalControl.Instance.actionPointsFenrir.ToString();
        painelStatusFenrir.SetActive(true);
        painelStatusHanzo.SetActive(false);
        painelSkills.SetActive(false);
    }

    public void Skills()
    {
        painelSkills.SetActive(true);
        menuPause.SetActive(false);
        painelStatusHanzo.SetActive(false);
        painelStatusFenrir.SetActive(false);
    }

    public void VoltaMenu()
    {
        Destroy(FindObjectOfType<GlobalControl>().gameObject);
        Destroy(FindObjectOfType<Canvas>().gameObject);
        SceneManager.LoadScene("Menu");
        GlobalControl.Instance.comecouJogo = false;
    }

    public void VoltaPause()
    {
        menuEquips.enabled = false;
        painelStatusHanzo.SetActive(false);
        painelStatusFenrir.SetActive(false);
        painelSkills.SetActive(false);
        painelSlots.SetActive(false);
        menuPause.SetActive(true);
    }
}
