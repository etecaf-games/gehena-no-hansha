using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : MonoBehaviour
{
    public Inventory inventario;
    public string liderDaParty = "Glenn";
    private bool pause = false;
    public GameObject menuPause, menuTalentos, statusHanzo, statusFenrir, menuSkills;
    public Image menuEquips, botaoVoltar, Slots;
    //public DialogueManager dialogueManager;
    public GameObject carinha, furry;
    public Glenn glenn;
    private Player player;
    //public Thiess thiess;
 
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        glenn = GetComponentInChildren<Glenn>(true);
        //thiess = GetComponentInChildren<Thiess>(true);
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
            Player.possoAndar = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Player.possoPausar == true)
        {
            if (Pause == true)
            {
                Pause = false;
                menuSkills.SetActive(false);
                menuPause.SetActive(false);
                menuEquips.enabled = false;
                menuTalentos.SetActive(false);
                statusHanzo.SetActive(false);
                statusFenrir.SetActive(false);
                inventario.FechaInventario();
                Player.possoAndar = true;
                //thiess.possoAndar = true;
            }
            else
            {
                Pause = true;
                menuPause.SetActive(true);

                Player.possoAndar = false;
                //thiess.possoAndar = false;
                //carinhaItem.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (liderDaParty == "Glenn" && (Player.possoMudar))
            {
                liderDaParty = "Thiess";
                Debug.Log("O lider da party é " + liderDaParty);
                
                furry.SetActive(true);
                furry.transform.position = new Vector3(carinha.transform.position.x, carinha.transform.position.y, carinha.transform.position.z);

                carinha.gameObject.SetActive(false);

            }

            else if (liderDaParty == "Thiess" && (Player.possoMudar))
            {
                liderDaParty = "Glenn";
                Debug.Log("O lider da party é " + liderDaParty);
                carinha.SetActive(true);
                carinha.transform.position = new Vector3(furry.transform.position.x, furry.transform.position.y, furry.transform.position.z);
                furry.gameObject.SetActive(false);

            }
        }
    }
}
