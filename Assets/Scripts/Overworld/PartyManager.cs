using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public string liderDaParty = "Glenn";
    public bool pause = false;
    public GameObject menuPause, menuTalentos, menuInventario, menuEquips;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pause == true)
            {
                pause = false;
                menuPause.SetActive(false);
                menuEquips.SetActive(false);
                menuInventario.SetActive(false);
                menuTalentos.SetActive(false);
            }
            else
            {
                pause = true;
                menuPause.SetActive(true);
            }
        }
    }
}
