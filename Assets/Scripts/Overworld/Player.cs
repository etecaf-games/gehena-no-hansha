using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocidade = 1.5f;
    public SpriteRenderer spritePlayer;
    public static bool possoAndar = true;
    public static bool possoPausar = true;
    private Animator PlayerAnim;
    public bool ToAndando = false;
    public PartyManager PartyManager;
    public Tutorial Tutorial;
    public static bool possoMudar = false;

    public DialogueManager dialogueManager;
    private void Awake()
    {
        PlayerAnim = GetComponent<Animator>();
    }
    void Start()
    {
        if (GlobalControl.Instance.comecouJogo == true)
        {
            possoMudar = true;

        }
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
            PlayerAnim.SetInteger("Transicao", 1);
        }

        else if (!ToAndando)
        {
            PlayerAnim.SetInteger("Transicao", 0);
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

    //void OnTriggerEnter2D(Collider2D quem)
    //{
    //    if (quem.tag == "Enemy")
    //    {
    //        SceneManager.LoadScene("CorridorCombat");
    //        this.gameObject.GetComponent<Image>().enabled = false;
    //    }
    //}
}