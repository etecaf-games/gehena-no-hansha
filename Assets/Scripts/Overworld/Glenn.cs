using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Glenn : MonoBehaviour
{

    public float velocidade = 1.5f;
    public SpriteRenderer spritePlayer;
    public bool Furtividade = true;
    public bool agil, confiavel, disciplinado = false;
    public int SocialXp = 0;
    public bool Furtivo = false;
    public GameObject excalamacao;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            if (Furtividade == true)
            {
                Color Opacidade = spritePlayer.color;
                Opacidade.a = 0.5f;
                velocidade = 0.5f;
                Furtivo = true;
            }
        }
        else
        {
                velocidade = 1.5f;
                Furtivo = false;
        }
        }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + velocidade * Time.fixedDeltaTime, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - velocidade * Time.fixedDeltaTime, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + velocidade * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            spritePlayer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - velocidade * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            spritePlayer.flipX = true;
        }
    }


    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Enemy" && Furtivo == false)
        {
            SceneManager.LoadScene("CorridorCombat");
        }

        if (quem.tag == "Interagivel" || quem.tag == "Npc") 
        {
            excalamacao.SetActive(true);
            
        }
        
    }

    void OnTriggerExit2D(Collider2D QUEM)
    {
        if (QUEM.tag == "Npc" | QUEM.tag == "Interagivel")
        {
            excalamacao.SetActive(false);
            
        }
    }
}

