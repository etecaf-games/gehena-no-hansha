using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int Mementos = 0;

    #region Status Thiess

    public int XpThiess;
    public bool vigoroso, combatente, irritado;
   
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
    public int XpGlenn = 100;
    public bool agil, confiavel = false;
    public bool furtivo = true;
    #endregion
    
    #region interacoes
    public bool ganhouxp, pegouGrampo, falouThiess, memento1, olhouLixo, olhouCarteira = false;
    public static bool entrouSala1 = false;
    public bool comecouJogo = false;
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
