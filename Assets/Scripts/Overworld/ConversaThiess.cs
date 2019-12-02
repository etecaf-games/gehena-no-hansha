using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConversaThiess : MonoBehaviour
{
    public Dialogo dialogo;
    public DialogueManager dialogueManager;
    public Glenn glenn;
    public Thiess thiess;
    public GameObject exclamacao;
    public bool interacao = false;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (GlobalControl.Instance.comecouJogo == true && GlobalControl.Instance.thiessParty == true)
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interacao == true)
        {
            if (dialogueManager.PassandoDialogo == false)
            {
                GatilhoThiess();
                GlobalControl.Instance.thiessParty = true;
            }
            else
            {
                dialogueManager.DisplayNextSentence();
            }

        }

        if (dialogueManager.PassandoDialogo == false && GlobalControl.Instance.thiessParty == true)
        {
            Player.possoAndar = true;
            Player.possoMudar = true;
            Destroy(this.gameObject);
        }
    }


    

    public void GatilhoThiess()
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



