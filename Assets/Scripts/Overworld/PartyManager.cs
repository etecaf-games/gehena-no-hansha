using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : MonoBehaviour
{
    public string liderDaParty = "Glenn";
    private bool pause = false;
    public GameObject menuPause, menuTalentos, carinhaItem;
    //public Image menuEquips;

    public Glenn glenn;
    public Thiess thiess;
    private void Awake()
    {
        glenn = GetComponentInChildren<Glenn>(true);
        thiess = GetComponentInChildren<Thiess>(true);
    }
    public bool Pause
    {
        get
        {
            return pause;
        }
        set
        {
            pause = value;
            glenn.possoAndar = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Pause == true)
            {
                Pause = false;
                //menuPause.SetActive(false);
                //menuEquips.enabled = false;
                //menuTalentos.SetActive(false);

                glenn.possoAndar = true;
                thiess.possoAndar = true;
                //carinhaItem.SetActive(false);
            }
            else
            {
                Pause = true;
                //menuPause.SetActive(true);

                glenn.possoAndar = false;
                thiess.possoAndar = false;
                //carinhaItem.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (liderDaParty == "Glenn" && (glenn.possoAndar || thiess.possoAndar))
            {
                liderDaParty = "Thiess";
                Debug.Log("O lider da party é " + liderDaParty);
                thiess.gameObject.SetActive(true);
                thiess.transform.position = new Vector3(glenn.transform.position.x, glenn.transform.position.y, glenn.transform.position.z);

                glenn.gameObject.SetActive(false);

            }

            else if (liderDaParty == "Thiess" && (glenn.possoAndar || thiess.possoAndar))
            {
                liderDaParty = "Glenn";
                Debug.Log("O lider da party é " + liderDaParty);
                glenn.gameObject.SetActive(true);
                glenn.transform.position = new Vector3(thiess.transform.position.x, thiess.transform.position.y, thiess.transform.position.z);
                thiess.gameObject.SetActive(false);

            }
        }
    }
}
