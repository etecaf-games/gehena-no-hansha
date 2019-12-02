using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public bool ToNaIntro = true;
    public GameObject intro;

    public void acabei()
    {
        Destroy(intro);
    }
}
