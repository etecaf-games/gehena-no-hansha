using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retorno : MonoBehaviour
{
    public GameObject player;
    public Transform retorno;
    public GameObject inimigoCorredor, inimigoSala1, inimigoSala2;
    // Start is called before the first frame update
    void Start()
    {
        //inimigo = GameObject.FindWithTag("Enemy");
        if (GlobalControl.Instance.comecouLutaSala1 == true || GlobalControl.Instance.comecouLutaSala2 == true || GlobalControl.Instance.comecouLutaCorredor == true)
        {
            player.transform.position = retorno.position;
            GlobalControl.Instance.comecouLutaSala1 = false;
            GlobalControl.Instance.comecouLutaSala2 = false;
            GlobalControl.Instance.comecouLutaCorredor = false;
        }

        if (GlobalControl.Instance.ganhouLutaSala1 == true)
        {
            Destroy(inimigoSala1);
        }

        if (GlobalControl.Instance.ganhouLutaSala2 == true)
        {
            Destroy(inimigoSala2);
        }

        if (GlobalControl.Instance.ganhouLutaCorredor == true)
        {
            Destroy(inimigoCorredor);
        }
    }
}
