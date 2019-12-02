using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int Mementos = 0;

    #region Status Thiess

    public int XpThiess = 0;
    public bool vigoroso, combatente, explosivo;

    #endregion

    #region StatusFenrir

    public int HPBaseFenrir = 5;
    public int SPBaseFenrir = 4;
    public int moveFenrir = 2;
    public int rangeFenrir = 1;
    public int actionPointsFenrir = 3;
    public int strengthFenrir = 3;
    public int attackFenrir = 4;
    public int resistanceFenrir = 2;
    public int defenseFenrir = 2;
    public int agilityFenrir = 2;
    public int magicFenrir = 1;
    public int vitalityFenrir = 2;
    public int spiritFenrir = 1;

    #endregion

    #region StatusHanzo

    public int HPBaseHanzo = 3;
    public int SPBaseHanzo = 3;
    public int moveHanzo = 3;
    public int rangeHanzo = 2;
    public int actionPointsHanzo = 4;
    public int strengthHanzo = 2;
    public int attackHanzo = 3;
    public int resistanceHanzo = 1;
    public int defenseHanzo = 3;
    public int agilityHanzo = 3;
    public int magicHanzo = 2;
    public int vitalityHanzo = 1;
    public int spiritHanzo = 2;

    #endregion


    #region StatusGlenn
    public int XpGlenn = 0;
    public bool agil, confiavel = false;
    public bool furtivo = true;
    #endregion

    #region interacoes
    public bool ganhouxp, pegouGrampo, falouThiess, memento1, memento2, olhouLixo, olhouCarteira, thiessParty = false;
    public static bool entrouSala1, entrouSala2, subiuTerraco = false;
    public bool comecouJogo, tutorial01, tutorial02 = false;
    public bool comecouLutaCorredor, comecouLutaSala1, comecouLutaSala2, comecouLutaTerraco = false;
    public bool ganhouLutaCorredor, ganhouLutaSala1, ganhouLutaSala2 = false;

    #endregion


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
