using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraStatusFenrir : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject painelStatusFenrir, painelStatusHanzo;
    public int valor, custo;
    public Text valorSXP, ValorHp, ValorSp, ValorMove, ValorAp, ValorAtk, ValorFor, ValorDef, ValorRes, ValorAgi, ValorVit, ValorEsp, ValorMag;

    public void CompraStatusAtk()
    {
        valor = GlobalControl.Instance.attackFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.attackFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.attackFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.attackFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.attackFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.attackFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;


            }
        }
    }


    public void CompraStatusFor()
    {
        valor = GlobalControl.Instance.strengthFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.strengthFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.strengthFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.strengthFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.strengthFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.strengthFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;


            }
        }
    }

    public void CompraStatusDef()
    {
        valor = GlobalControl.Instance.defenseFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.defenseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.defenseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.defenseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.defenseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.defenseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;


            }
        }
    }

    public void CompraStatusRes()
    {
        valor = GlobalControl.Instance.resistanceFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.resistanceFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.resistanceFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.resistanceFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.resistanceFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.resistanceFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusAgi()
    {
        valor = GlobalControl.Instance.agilityFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.agilityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.agilityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.agilityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.agilityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.agilityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusVit()
    {
        valor = GlobalControl.Instance.vitalityFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.vitalityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.vitalityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.vitalityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.vitalityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.vitalityFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusEsp()
    {
        valor = GlobalControl.Instance.spiritFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.spiritFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.spiritFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.spiritFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.spiritFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.spiritFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusMag()
    {
        valor = GlobalControl.Instance.magicFenrir;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.magicFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.magicFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.magicFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.magicFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.magicFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusHp()
    {
        valor = GlobalControl.Instance.HPBaseFenrir;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.HPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.HPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.HPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.HPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.HPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusSp()
    {
        valor = GlobalControl.Instance.SPBaseFenrir;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.SPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.SPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.SPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.SPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.SPBaseFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusMove()
    {
        valor = GlobalControl.Instance.moveFenrir;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.moveFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.moveFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.moveFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.moveFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.moveFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusAp()
    {
        valor = GlobalControl.Instance.actionPointsFenrir;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpThiess >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.actionPointsFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.actionPointsFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.actionPointsFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.actionPointsFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpThiess -= custo;
                    GlobalControl.Instance.actionPointsFenrir++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }
    public void Atualiza()
    {
        valorSXP.text = "XP: " + GlobalControl.Instance.XpThiess.ToString();
        ValorAtk.text = "Ataque: " + GlobalControl.Instance.attackFenrir.ToString();
        ValorDef.text = "Defesa: " + GlobalControl.Instance.defenseFenrir.ToString();
        ValorFor.text = "Força: " + GlobalControl.Instance.strengthFenrir.ToString();
        ValorRes.text = "Resistência: " + GlobalControl.Instance.resistanceFenrir.ToString();
        ValorAgi.text = "Agilidade: " + GlobalControl.Instance.agilityFenrir.ToString();
        ValorVit.text = "Vitalidade: " + GlobalControl.Instance.vitalityFenrir.ToString();
        ValorEsp.text = "Espírito: " + GlobalControl.Instance.spiritFenrir.ToString();
        ValorMag.text = "Magia: " + GlobalControl.Instance.magicFenrir.ToString();
        ValorHp.text = "HP Base: " + GlobalControl.Instance.HPBaseFenrir.ToString();
        ValorSp.text = "SP Base: " + GlobalControl.Instance.SPBaseFenrir.ToString();
        ValorMove.text = "Move: " + GlobalControl.Instance.moveFenrir.ToString();
        ValorAp.text = "PA: " + GlobalControl.Instance.actionPointsFenrir.ToString();
    }

    public void ExitTStatus()
    {
        painelStatusFenrir.SetActive(false);
        painelStatusHanzo.SetActive(false);
        menuPause.SetActive(true);
    }

    //public void Change()
    //{
    //    painelStatusFenrir.SetActive(false);
    //    painelStatusHanzo.SetActive(true);
    //}
}
