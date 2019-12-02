using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleProximoComoJogar : MonoBehaviour
{
    public GameObject TutorialMovimento, TutorialInetra, TutorialMonstros;

    public void AtivaIntera ()
    {
        TutorialMovimento.SetActive(false);
        TutorialInetra.SetActive(true);
        TutorialMonstros.SetActive(false);
    }

    public void AtivaMonstros()
    {
        TutorialMovimento.SetActive(false);
        TutorialInetra.SetActive(false);
        TutorialMonstros.SetActive(true);
    }

    public void AtivaMovimento()
    {
        TutorialMovimento.SetActive(true);
        TutorialInetra.SetActive(false);
        TutorialMonstros.SetActive(false);
    }

}
