using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> nomes;
    public GameObject painel, botao;
    public Text nameText;
    public Text dialogueText;
    private bool passandoDialogo = false;
    //private Glenn glenn;
    //private Thiess thiess;
    private Player player;

    public bool PassandoDialogo
    {
        get
        {
            return passandoDialogo;
        }
        set
        {
            passandoDialogo = value;
            Player.possoPausar = !passandoDialogo;
            Player.possoAndar = !passandoDialogo;
            Player.possoMudar = !passandoDialogo;
            //Debug.Log(player.possoAndar);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        sentences = new Queue<string>();
        nomes = new Queue<string>();
    }
    public void ComecaDialogo(Dialogo dialogo)
    {
        PassandoDialogo = true;
        painel.SetActive(true);
        botao.SetActive(true);

        sentences.Clear();
        nomes.Clear();

        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string nome in dialogo.nomes)
        {
            nomes.Enqueue(nome);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 && nomes.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = nomes.Dequeue();
        dialogueText.text = sentence;
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentece)
    {
        dialogueText.text = "";
        foreach (char letter in sentece.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }


    }
    void EndDialogue()
    {
        PassandoDialogo = false;
        painel.SetActive(false);
        botao.SetActive(false);
    }
}
