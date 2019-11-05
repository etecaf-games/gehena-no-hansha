using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarukaNpc : MonoBehaviour
{
    private Glenn glenn;
    private PartyManager party; 
    public SpriteRenderer spriteHaruka;
    public int XPSGanha = 25;
    public bool ganhouxp = false;
    public bool interacao = false;
    public Dialogo dialogo;
    public Dialogo dialogo2;
    
    // Start is called before the first frame update
    void Start()
    {
        glenn = GameObject.FindWithTag("Player").GetComponent<Glenn>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && interacao == true && party.liderDaParty == "Glenn")
        {
            if (ganhouxp == false)
            {
                glenn.SocialXp += 50;
                ganhouxp = true;
                GatilhoDialogo();
            }
            else
            {
                GatilhoDialogo2();
            }
        }
    }

    public void GatilhoDialogo()
    {
   
            FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo);
    }

      public void GatilhoDialogo2()
        {
            FindObjectOfType<DialogueManager>().ComecaDialogo(dialogo2);
        }

      void OnTriggerEnter2D(Collider2D quem)
      {
          if (quem.tag == "Player")
          {
              interacao = true;
          }
      }
    }

