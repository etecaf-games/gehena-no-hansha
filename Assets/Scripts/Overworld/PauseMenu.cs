using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject painelTalentos;
    public GameObject menuPause;
    public GameObject menuInventario;
    public GameObject Equips;
    public Glenn glenn;
    public Text valorSXP;

    public void Talentos()
    {
        valorSXP.text = "SXP: " + glenn.SocialXp.ToString();
        painelTalentos.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Inventario()
    {
        menuInventario.SetActive(true);
        Equips.SetActive(true);
        menuPause.SetActive(false);
    }
}
