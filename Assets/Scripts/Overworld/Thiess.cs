using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Thiess : MonoBehaviour
{
    public float velocidade = 1.5f;
    public SpriteRenderer spritePlayer;
    public bool furtivo;
    public bool agil, confiavel;
    public int Xp;
    public bool possoAndar = true;
    public bool vigoroso, irritado, combatente;
    private Animator ThiessAnim;
    private bool ToAndando = false;
    public PartyManager PartyManager;
    public Tutorial Tutorial;
    public bool possoMudar = false;

    public DialogueManager dialogueManager;
    private void Awake()
    {
        ThiessAnim = GetComponent<Animator>();
    }
    void Start()
    {
        Xp = GlobalControl.Instance.XpThiess;
        furtivo = GlobalControl.Instance.furtivo;
        agil = GlobalControl.Instance.agil;
        confiavel = GlobalControl.Instance.confiavel;
    }

    void FixedUpdate()
    {
        if (ToAndando)
        {
            ThiessAnim.SetInteger("Transicao", 1);
        }

        else if (!ToAndando)
        {
            ThiessAnim.SetInteger("Transicao", 0);
        }
        if (!possoAndar)
        {
            ToAndando = false;
        }
        if (possoAndar)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + velocidade * Time.fixedDeltaTime, transform.position.z);
                ToAndando = true;
            }
            else
            {
                ToAndando = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - velocidade * Time.fixedDeltaTime, transform.position.z);
                ToAndando = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + velocidade * Time.fixedDeltaTime, transform.position.y, transform.position.z);
                ToAndando = true;
                spritePlayer.flipX = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - velocidade * Time.fixedDeltaTime, transform.position.y, transform.position.z);
                ToAndando = true;
                spritePlayer.flipX = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Enemy")
        {
            SceneManager.LoadScene("CorridorCombat");
            this.gameObject.GetComponent<Image>().enabled = false;
        }
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.XpThiess = Xp;
        GlobalControl.Instance.agil = agil;
        GlobalControl.Instance.furtivo = furtivo;
        GlobalControl.Instance.confiavel = confiavel;
    }
}