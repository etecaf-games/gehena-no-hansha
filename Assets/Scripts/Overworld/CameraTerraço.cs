using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTerraço : MonoBehaviour
{
 public Transform Playertransform;
    public float limitedireita;
    public float limiteesquerda;
    public float limitebaixo;
    public float limitecima;
    public bool travaCameraHorizontal = true;
    public bool travaCameraVertical = true;
    public PartyManager party;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private bool TravouNosLimites(float limiteEsquerda, float limiteDireita, float limiteBaixo, float limiteCima)
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

        if (Playertransform.position.y <= limiteCima)
        {
            transform.position = new Vector3(transform.position.x, limiteCima, transform.position.z);
            passouDosLimites = true;
        }

        else if (Playertransform.position.y >= limiteBaixo)
        {
            transform.position = new Vector3(transform.position.x, limiteBaixo, transform.position.z);
            passouDosLimites = true;
        }

        return passouDosLimites;
    }

    //private bool TravouNosLimitesVerticais(float limiteBaixo, float limiteCima)
    //{
    //    bool passouDosLimitesV = false;
    //    if (Playertransform.position.y <= limiteCima)
    //    {
    //        transform.position  = new Vector3(transform.position.x, limiteCima, transform.position.z);
    //        passouDosLimitesV = true;
    //    }

    //    else if (Playertransform.position.y >= limiteBaixo)
    //    {
    //        transform.position = new Vector3(transform.position.x, limiteBaixo, transform.position.z);
    //        passouDosLimitesV = true;
    //    }
    //    return passouDosLimitesV;
    //}

    private void LateUpdate()
    {
        travaCameraHorizontal = TravouNosLimites(limiteesquerda, limitedireita, limitecima, limitebaixo);
        travaCameraVertical = TravouNosLimites(limiteesquerda, limitedireita, limitecima, limitebaixo);
        if (!travaCameraHorizontal)
        {
            transform.position = new Vector3(Playertransform.position.x, Playertransform.position.y, this.transform.position.z);
        }
        
        if (!travaCameraVertical)
        {
            transform.position = new Vector3(Playertransform.position.x, Playertransform.position.y, this.transform.position.z);
        }

        //travaCamera = TravouNosLimitesVerticais(limitebaixo, limitecima);
        //if (!travaCamera)
        //{
        //    transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);
        //}
    }
}
