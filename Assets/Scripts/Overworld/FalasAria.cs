using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalasAria : MonoBehaviour
{
    public Dialogo dialogo;
    public Dialogo dialogo2;
    public Dialogo dialogo3;
    public Dialogo dialogo4;
    public DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueManager.PassandoDialogo == true)
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Player")
        {
            if (GlobalControl.Instance.Mementos == 0)
            {
                GatilhoDialogoAria();
            }
            else if (GlobalControl.Instance.Mementos == 1)
            {
                GatilhoDialogoAria2();
            }
            else if (GlobalControl.Instance.Mementos == 2)
            {
                GatilhoDialogoAria3();
            }
            else if (GlobalControl.Instance.Mementos == 3)
            {
                GatilhoDialogoAria4();
            }

        
        }
    }

    public void GatilhoDialogoAria()
    {

        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo);

    }

    public void GatilhoDialogoAria2()
    {

        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo2);

    }

    public void GatilhoDialogoAria3()
    {
        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo3);
    }
    
    public void GatilhoDialogoAria4()
    {
        FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo4);
    }
}
