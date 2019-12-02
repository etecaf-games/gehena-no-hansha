using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraStatus : MonoBehaviour
{
    //public HanzoTeste Hanzo;
    //public Glenn glenn;
    //public GameObject Botao1, Botao2, Botao3, Botao4, Botao5, Botao6, Botao7,Botao8, Botao9, Botao10, Botao11, Botao12;
    public GameObject menuPause;
    public GameObject painelStatusHanzo, painelStatusFenrir;
    public int valor, custo;
    public Text valorSXP, ValorHp, ValorSp, ValorMove, ValorAp, ValorAtk, ValorFor, ValorDef, ValorRes, ValorAgi, ValorVit, ValorEsp, ValorMag;
    //public Text valorSXP2, ValorHp2, ValorSp2, ValorMove2, ValorAp2, ValorAtk2, ValorFor2, ValorDef2, ValorRes2, ValorAgi2, ValorVit2, ValorEsp2, ValorMag2;

    void Start()
    {
        //Atualiza();
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in players)
        //{
        //    if (player.name == "Hanzo")
        //    {
        //        Hanzo = player.GetComponent<HanzoTeste>();
        //    }
        //    else if (player.name == "Glenn")
        //    {
        //        glenn = player.GetComponent<Glenn>();
        //    }
        //}
    }
    public void CompraStatusAtk()
    {
        valor = GlobalControl.Instance.attackHanzo;
        custo = 25*valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.attackHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.attackHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.attackHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.attackHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.attackHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;


            }
        }
    }
 

        public void CompraStatusFor()
    {
        valor = GlobalControl.Instance.strengthHanzo;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.strengthHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.strengthHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.strengthHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.strengthHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.strengthHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;


            }
        }
    }

        public void CompraStatusDef()
        {
            valor = GlobalControl.Instance.defenseHanzo;
            custo = 25 * valor;
            if (GlobalControl.Instance.XpGlenn >= custo)
            {
                switch (valor)
                {
                    case 1:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.defenseHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 2:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.defenseHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 3:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.defenseHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 4:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.defenseHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 5:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.defenseHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;


                }
            }
        }

        public void CompraStatusRes()
        {
            valor = GlobalControl.Instance.resistanceHanzo;
            custo = 25 * valor;
            if (GlobalControl.Instance.XpGlenn >= custo)
            {
                switch (valor)
                {
                    case 1:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.resistanceHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 2:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.resistanceHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 3:
                        GlobalControl.Instance.XpGlenn -= custo;
                       GlobalControl.Instance.resistanceHanzo++;
                       Atualiza();
                        //SavePlayer();
                        break;

                    case 4:
                        GlobalControl.Instance.XpGlenn -= custo;
                       GlobalControl.Instance.resistanceHanzo++;
                       Atualiza();
                        //SavePlayer();
                        break;

                    case 5:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.resistanceHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;
                }
            }
        }

        public void CompraStatusAgi()
        {
            valor = GlobalControl.Instance.agilityHanzo;
            custo = 25 * valor;
            if (GlobalControl.Instance.XpGlenn >= custo)
            {
                switch (valor)
                {
                    case 1:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.agilityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 2:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.agilityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 3:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.agilityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 4:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.agilityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 5:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.agilityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;
                }
            }
        }

        public void CompraStatusVit()
        {
            valor = GlobalControl.Instance.vitalityHanzo;
            custo = 25 * valor;
            if (GlobalControl.Instance.XpGlenn >= custo)
            {
                switch (valor)
                {
                    case 1:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.vitalityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 2:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.vitalityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 3:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.vitalityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 4:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.vitalityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 5:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.vitalityHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;
                }
            }
        }
       
    public void CompraStatusEsp()
        {
            valor = GlobalControl.Instance.spiritHanzo;
            custo = 25 * valor;
            if (GlobalControl.Instance.XpGlenn >= custo)
            {
                switch (valor)
                {
                    case 1:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.spiritHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 2:
                        GlobalControl.Instance.XpGlenn -= custo;
                      GlobalControl.Instance.spiritHanzo++;
                      Atualiza();
                        //SavePlayer();
                        break;

                    case 3:
                        GlobalControl.Instance.XpGlenn -= custo;
                       GlobalControl.Instance.spiritHanzo++;
                       Atualiza();
                        //SavePlayer();
                        break;

                    case 4:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.spiritHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;

                    case 5:
                        GlobalControl.Instance.XpGlenn -= custo;
                        GlobalControl.Instance.spiritHanzo++;
                        Atualiza();
                        //SavePlayer();
                        break;
                }
            }
        }

    public void CompraStatusMag()
    {
        valor = GlobalControl.Instance.magicHanzo;
        custo = 25 * valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.magicHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.magicHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.magicHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.magicHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.magicHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusHp()
    {
        valor = GlobalControl.Instance.HPBaseHanzo;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.HPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.HPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.HPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.HPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.HPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusSp()
    {
        valor = GlobalControl.Instance.SPBaseHanzo;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.SPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.SPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.SPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.SPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.SPBaseHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusMove()
    {
        valor = GlobalControl.Instance.moveHanzo;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpGlenn  >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.moveHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.moveHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                   GlobalControl.Instance.moveHanzo++;
                   Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.moveHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                   GlobalControl.Instance.moveHanzo++;
                   Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    public void CompraStatusAp()
    {
        valor = GlobalControl.Instance.actionPointsHanzo;
        custo = 50 * valor;
        if (GlobalControl.Instance.XpGlenn >= custo)
        {
            switch (valor)
            {
                case 1:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.actionPointsHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 2:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.actionPointsHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 3:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.actionPointsHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 4:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.actionPointsHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;

                case 5:
                    GlobalControl.Instance.XpGlenn -= custo;
                    GlobalControl.Instance.actionPointsHanzo++;
                    Atualiza();
                    //SavePlayer();
                    break;
            }
        }
    }

    //public void Atualiza()
    //{
    //    valorSXP.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
    //    ValorAtk.text = "Ataque: " + Hanzo.attack.ToString();
    //    ValorDef.text = "Defesa: " + Hanzo.defense.ToString();
    //    ValorFor.text = "Força: " + Hanzo.strength.ToString();
    //    ValorRes.text = "Resistência: " + Hanzo.resistance.ToString();
    //    ValorAgi.text = "Agilidade: " + Hanzo.agility.ToString();
    //    ValorVit.text = "Vitalidade: " + Hanzo.vitality.ToString();
    //    ValorEsp.text = "Espírito: " + Hanzo.spirit.ToString();
    //    ValorMag.text = "Magia: " + Hanzo.magic.ToString();
    //    ValorHp.text = "HP Base: " + Hanzo.HPBase.ToString();
    //    ValorSp.text = "SP Base: " + Hanzo.SPBase.ToString();
    //    ValorMove.text = "Move: " + Hanzo.move.ToString();
    //    ValorAp.text = "PA: " + Hanzo.actionPoints.ToString();
    //}

    public void Atualiza()
    {
        valorSXP.text = "XP: " + GlobalControl.Instance.XpGlenn.ToString();
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
    }

    public void ExitTStatus()
    {
        painelStatusHanzo.SetActive(false);
        painelStatusFenrir.SetActive(false);
        menuPause.SetActive(true);
    }

    //public void Change()
    //{
    //    valorSXP2.text = "XP: " + GlobalControl.Instance.XpThiess.ToString();
    //    ValorAtk2.text = "Ataque: " + GlobalControl.Instance.attackFenrir.ToString();
    //    ValorDef2.text = "Defesa: " + GlobalControl.Instance.defenseFenrir.ToString();
    //    ValorFor2.text = "Força: " + GlobalControl.Instance.strengthFenrir.ToString();
    //    ValorRes2.text = "Resistência: " + GlobalControl.Instance.resistanceFenrir.ToString();
    //    ValorAgi2.text = "Agilidade: " + GlobalControl.Instance.agilityFenrir.ToString();
    //    ValorVit2.text = "Vitalidade: " + GlobalControl.Instance.vitalityFenrir.ToString();
    //    ValorEsp2.text = "Espírito: " + GlobalControl.Instance.spiritFenrir.ToString();
    //    ValorMag2.text = "Magia: " + GlobalControl.Instance.magicFenrir.ToString();
    //    ValorHp2.text = "HP Base: " + GlobalControl.Instance.HPBaseFenrir.ToString();
    //    ValorSp2.text = "SP Base: " + GlobalControl.Instance.SPBaseFenrir.ToString();
    //    ValorMove2.text = "Move: " + GlobalControl.Instance.moveFenrir.ToString();
    //    ValorAp2.text = "PA: " + GlobalControl.Instance.actionPointsFenrir.ToString();
    //    painelStatusFenrir.SetActive(true);
    //    painelStatusHanzo.SetActive(false);
    //}

    //public void SavePlayer()
    //{
    //    GlobalControl.Instance.XpGlenn = GlobalControl.Instance.XpGlenn;
    //    GlobalControl.Instance.HPBaseHanzo = Hanzo.HPBase;
    //    GlobalControl.Instance.SPBaseHanzo = Hanzo.SPBase;
    //    GlobalControl.Instance.moveHanzo = Hanzo.move;
    //    GlobalControl.Instance.rangeHanzo = Hanzo.range;
    //    GlobalControl.Instance.actionPointsHanzo = Hanzo.actionPoints;
    //    GlobalControl.Instance.strengthHanzo = Hanzo.strength;
    //    GlobalControl.Instance.attackHanzo = Hanzo.attack;
    //    GlobalControl.Instance.resistanceHanzo = Hanzo.resistance;
    //    GlobalControl.Instance.defenseHanzo = Hanzo.defense;
    //    GlobalControl.Instance.agilityHanzo = Hanzo.agility;
    //    GlobalControl.Instance.magicHanzo = Hanzo.magic;
    //    GlobalControl.Instance.vitalityHanzo = Hanzo.vitality;
    //    GlobalControl.Instance.spiritHanzo = Hanzo.spirit;
    //}
}
