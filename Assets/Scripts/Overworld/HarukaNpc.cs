using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarukaNpc : MonoBehaviour
{
    public PartyManager party;
    public GameObject exclamacao;
    public SpriteRenderer spriteHaruka;
    public Inventory inventoryscript;
    public bool falouThiess = false;
    public bool interacao = false;
    public Dialogo dialogo;
    public Dialogo dialogo2;
    public Dialogo dialogo3;
    public Dialogo dialogo4;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inventoryscript = FindObjectOfType<Inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interacao == true)
        {
            if (dialogueManager.PassandoDialogo == false)
            {
                if (party.liderDaParty == "Glenn")
                {
                    if (GlobalControl.Instance.ganhouxp == false)
                    {
                        GlobalControl.Instance.XpGlenn += 50;
                        GlobalControl.Instance.ganhouxp = true;
                        GatilhoDialogo();
                        //SavePlayer();
                    }
                    else if (GlobalControl.Instance.ganhouxp == true && GlobalControl.Instance.pegouGrampo == false)
                    {
                        GlobalControl.Instance.XpGlenn += 25;
                        GlobalControl.Instance.pegouGrampo = true;
                        //SavePlayer();
                        inventoryscript.GiveItem(8);
                        GatilhoDialogo2();
                    }

                    else
                    {
                        GatilhoDialogo3();
                    }
                }
                else if (party.liderDaParty == "Thiess")
                {
                    if (falouThiess == false)
                    {
                        GatilhoDialogo4();
                        falouThiess = true;
                        GlobalControl.Instance.XpThiess += 50;
                        //SavePlayer();
                    }
                    else
                    {
                        GatilhoDialogo3();
                    }
                }

            }
            else
            {
                dialogueManager.DisplayNextSentence();
            }
        }
    }

    public void GatilhoDialogo()
    {

        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo);

    }

    public void GatilhoDialogo2()
    {
        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo2);

    }

    public void GatilhoDialogo3()
    {
        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo3);

    }

    public void GatilhoDialogo4()
    {
        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo4);

    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            interacao = true;
            for (int i = 0; i < quem.transform.childCount; i++)
            {
                Transform filho = quem.transform.GetChild(i);
                if (filho.name == "exclamacao_v1")
                {
                    GameObject exclamacao = filho.gameObject;
                    exclamacao.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            interacao = false;
            for (int i = 0; i < quem.transform.childCount; i++)
            {
                Transform filho = quem.transform.GetChild(i);
                if (filho.name == "exclamacao_v1")
                {
                    GameObject exclamacao = filho.gameObject;
                    exclamacao.SetActive(false);
                }
            }
        }
    }

    //public void SavePlayer()
    //{
    //    GlobalControl.Instance.XpGlenn = GlobalControl.Instance.XpGlenn;
    //    GlobalControl.Instance.XpThiess = GlobalControl.Instance.XpThiess;
    //    GlobalControl.Instance.pegouGrampo = pegouGrampo;
    //    GlobalControl.Instance.ganhouxp = ganhouxp;
    //    GlobalControl.Instance.falouThiess = falouThiess;
    //}
}

