using UnityEngine;

public class ArmárioÁria : MonoBehaviour
{
    public PartyManager party;
    private GameObject exclamacao;
    public HarukaNpc haruka;
    public Dialogo dialogoarmario1;
    public Dialogo dialogoarmario2;
    public bool interacao = false;

    private Inventory inventoryScript;
    private DialogueManager dialogueManager;
    void Start()
    {

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
                if (GlobalControl.Instance.ganhouxp == true)
                {
                    if (GlobalControl.Instance.pegouGrampo == false)
                    {
                        GatilhoDialogo();
                    }
                    else
                    {
                        if (GlobalControl.Instance.memento1 == false)
                        {
                           GlobalControl.Instance.XpGlenn += 25;
                           GlobalControl.Instance.XpThiess += 25;
                           GlobalControl.Instance.memento1 = true;
                            GlobalControl.Instance.Mementos++;
                            inventoryScript.GiveItem(6);
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
        if (quem.tag == "Player" && GlobalControl.Instance.ganhouxp == true)
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