using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Thiess : MonoBehaviour
{
    public float velocidade = 1.5f;
    public SpriteRenderer spritePlayer;
    public bool possoAndar = true;
    private Animator ThiessAnim;
    public bool ToAndando = false;
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
    }

    void FixedUpdate()
    {
        if (PartyManager.Pause)
        {
            possoAndar = false;
            possoMudar = false;
        }
        else if (PartyManager.Pause)
        {
            possoAndar = true;
            possoMudar = true;
        }
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
}