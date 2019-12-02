using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Transform Playertransform;
    public float limitedireita;
    public float limiteesquerda;
    public bool travaCamera = true;
    private PartyManager party;


    // Start is called before the first frame update
    void Start()
    {
        party = FindObjectOfType<PartyManager>();
        Playertransform = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        this.transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);

        if (party.liderDaParty == "Glenn")
        {
            Playertransform = party.carinha.transform;
        }
        else if (party.liderDaParty == "Thiess")
        {
            Playertransform = party.furry.transform;
        }
        
        //if (!travaCamera)
        //{
        //    if (Playertransform.position.x <= limiteesquerda)
        //    {
        //        travaCamera = true;
        //    }
        //    else if (Playertransform.position.x >= limitedireita)
        //    {
        //        travaCamera = true;
        //    }
        //}
        //else if (Playertransform.position.x > limiteesquerda && Playertransform.position.x < limitedireita)
        //{
        //    travaCamera = false;
        //}
    }

    private bool TravouNosLimitesHorizontais(float limiteEsquerda, float limiteDireita)
    {
        bool passouDosLimites = false;
        if (Playertransform.position.x >= limiteDireita)
        {
            transform.position = new Vector3(limiteDireita, transform.position.y, transform.position.z);
            passouDosLimites = true;
        }
        else if (Playertransform.position.x <= limiteEsquerda)
        {
            transform.position = new Vector3(limiteEsquerda, transform.position.y, transform.position.z);
            passouDosLimites = true;
        }

        return passouDosLimites;
    }

    private void LateUpdate()
    {
        travaCamera = TravouNosLimitesHorizontais(limiteesquerda, limitedireita);
        if (!travaCamera)
        {
            transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}