using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Glenn : MonoBehaviour
{
    public float velocidade = 1.5f;
    public SpriteRenderer spritePlayer;
    public  bool possoAndar = true;

    private Animator GlennAnim;
    private bool ToAndando = false;
    public PartyManager PartyManager;
    public Tutorial Tutorial;
    public bool possoMudar = false;

    public DialogueManager dialogueManager;
    private void Awake()
    {
        GlennAnim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (ToAndando)
        {
            GlennAnim.SetInteger("Transicao", 1);
        }

        else if (!ToAndando)
        {
            GlennAnim.SetInteger("Transicao", 0);
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

    //public void SavePlayer()
    //{
    //    GlobalControl.Instance.XpGlenn = Xp;
    //    GlobalControl.Instance.agil = agil;
    //    GlobalControl.Instance.furtivo = furtivo;
    //    GlobalControl.Instance.confiavel = confiavel;
    //}
}

