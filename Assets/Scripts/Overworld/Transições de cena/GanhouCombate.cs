using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GanhouCombate : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GlobalControl.Instance.comecouLutaSala1 == true)
            {
                SceneManager.LoadScene("Classroom");
                GlobalControl.Instance.XpThiess += 40;
                GlobalControl.Instance.XpGlenn += 40;
                //GlobalControl.Instance.comecouLutaSala1 = false;
                GlobalControl.Instance.ganhouLutaSala1 = true;
            }

            else if (GlobalControl.Instance.comecouLutaSala2 == true)
            {
                SceneManager.LoadScene("Classroom2");
                GlobalControl.Instance.XpThiess += 50;
                GlobalControl.Instance.XpGlenn += 50;
                //GlobalControl.Instance.comecouLutaSala2 = false;
                GlobalControl.Instance.ganhouLutaSala2 = true;
            }

            else if (GlobalControl.Instance.comecouLutaCorredor == true)
            {
                SceneManager.LoadScene("Corredor1");
                GlobalControl.Instance.XpThiess += 30;
                GlobalControl.Instance.XpGlenn += 30;
                //GlobalControl.Instance.comecouLutaCorredor = false;
                GlobalControl.Instance.ganhouLutaCorredor = true;
            }

            else if (GlobalControl.Instance.comecouLutaTerraco == true)
            {
                Destroy(FindObjectOfType<GlobalControl>().gameObject);
                Destroy(FindObjectOfType<Canvas>().gameObject);
                SceneManager.LoadScene("Menu");
                GlobalControl.Instance.comecouJogo = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(FindObjectOfType<GlobalControl>().gameObject);
            Destroy(FindObjectOfType<Canvas>().gameObject);
            SceneManager.LoadScene("Menu");
            GlobalControl.Instance.comecouJogo = false;
        }
        
    }
}
