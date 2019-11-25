using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarinhaItem : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.tag == "Canivete")
        {
            Debug.Log("To com canivete");
        }
    }
}
