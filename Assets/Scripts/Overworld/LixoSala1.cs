using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoSala1 : MonoBehaviour
{
    public PartyManager party;
    //public GameObject exclamacao;
    public Glenn glenn;
    public Thiess thiess;
    public Inventory inventoryscript;
    public Dialogo dialogo;
    public bool jaInteragiu = false;
    private DialogueManager dialogueManager;
    public bool interacao = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        jaInteragiu = GlobalControl.Instance.olhouLixo;
        inventoryscript = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interacao == true)
        {
            if (dialogueManager.PassandoDialogo == false)
            {
                if (jaInteragiu == false)
                {
                    GlobalControl.Instance.XpGlenn += 25;
                    GlobalControl.Instance.XpThiess += 25;
                    GatilhoDialogo();
                    inventoryscript.GiveItem(9);
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
}
