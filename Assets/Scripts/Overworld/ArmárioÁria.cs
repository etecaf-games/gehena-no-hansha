using UnityEngine;

public class ArmárioÁria : MonoBehaviour
{
    public PartyManager party;
    private GameObject exclamacao;
    public Glenn glenn;
    public Thiess thiess;
    public HarukaNpc haruka;
    public Dialogo dialogoarmario1;
    public Dialogo dialogoarmario2;
    public bool grampo = false;
    public bool interacao = false;
    public bool memento = false;

    private Inventory inventoryScript;
    private DialogueManager dialogueManager;
    void Start()
    {
        grampo = GlobalControl.Instance.pegouGrampo;
        memento = GlobalControl.Instance.memento1;

        GameObject gameMaster = GameObject.Find("GameMaster");
        inventoryScript = gameMaster.GetComponent<Inventory>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interacao == true)
        {
            if (dialogueManager.PassandoDialogo == false)
            {
                if (haruka.ganhouxp == true)
                {
                    if (grampo == false)
                    {
                        GatilhoDialogo();
                    }
                    else
                    {
                        if (memento == false)
                        {
                            glenn.Xp += 25;
                            thiess.Xp += 25;
                            memento = true;
                            GlobalControl.Instance.Mementos++;
                            inventoryScript.GiveItem(6);
                            SavePlayer();
                            GatilhoDialogo2();
                        }
                    }
                }
                else
                {
                    Debug.Log("Ganha xp antes porra");
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
        dialogueManager.ComecaDialogo(dialogoarmario1);
    }

    public void GatilhoDialogo2()
    {
        dialogueManager.ComecaDialogo(dialogoarmario2);
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