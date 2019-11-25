using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public bool ComecouoJogo = false;
    public bool pause = false;
    public GameObject menuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pause == false)
            {
                pause = true;
                menuPause.SetActive(true);
            }
            else
            {
                pause = false;
                menuPause.SetActive(false);
            }
        }
    }


    void Start()
    {
        if (GlobalControl.Instance.comecouJogo == false)
        {
            DontDestroyOnLoad(gameObject);
            GlobalControl.Instance.comecouJogo = true;
        }
        else if (GlobalControl.Instance.comecouJogo == true)
        {
            Destroy(gameObject);
        }
    }
}

