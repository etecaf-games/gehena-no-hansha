using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarukaNpc : MonoBehaviour
{
    public Glenn glenn;
    public Thiess thiess;
    public ArmárioÁria armario;
    public PartyManager party;
    public GameObject exclamacao;
    public SpriteRenderer spriteHaruka;
    public Inventory inventoryscript;
    public bool ganhouxp = false, pegouGrampo = false, falouThiess = false;
    public bool interacao = false;
    public Dialogo dialogo;
    public Dialogo dialogo2;
    public Dialogo dialogo3;
    public Dialogo dialogo4;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        ganhouxp = GlobalControl.Instance.ganhouxp;
        pegouGrampo = GlobalControl.Instance.pegouGrampo;
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
                    if (ganhouxp == false)
                    {
                        glenn.Xp += 50;
                        ganhouxp = true;
                        GatilhoDialogo();
                        SavePlayer();
                    }
                    else if (ganhouxp == true && pegouGrampo == false)
                    {
                        glenn.Xp += 25;
                        pegouGrampo = true;
                        armario.grampo = true;
                        SavePlayer();
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
                        thiess.Xp += 50;
                        SavePlayer();
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

    public void SavePlayer()
    {
        GlobalControl.Instance.XpGlenn = glenn.Xp;
        GlobalControl.Instance.XpThiess = thiess.Xp;
        GlobalControl.Instance.pegouGrampo = pegouGrampo;
        GlobalControl.Instance.ganhouxp = ganhouxp;
        GlobalControl.Instance.falouThiess = falouThiess;
    }
}

