using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteiraAria : MonoBehaviour
{
    public PartyManager party;
    public GameObject exclamacao;
    public Glenn glenn;
    public Thiess thiess;
    public Inventory inventoryscript;
    public Dialogo dialogo;
    public bool jaInteragiu = false;
    public bool interacao = false;
    public bool memento = false;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        jaInteragiu = GlobalControl.Instance.olhouCarteira;
        inventoryscript = FindObjectOfType<Inventory>();
        dialogueManager = FindObjectOfType<DialogueManager>();

    }


    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interacao == true)
        {
            if (dialogueManager.PassandoDialogo == false)
            {
                if (memento == false)
                {
                    GlobalControl.Instance.XpGlenn += 25;
                    GlobalControl.Instance.XpThiess += 25;
                    jaInteragiu = true;
                    memento = true;
                    GlobalControl.Instance.olhouCarteira = true;
                    GlobalControl.Instance.Mementos++;
                    inventoryscript.GiveItem(7);
                    SavePlayer();
                    GatilhoDialogo();
                }
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

    public void SavePlayer()
    {
        GlobalControl.Instance.memento1 = memento;

        
    }
}
