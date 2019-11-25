using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Transform Playertransform;
    public float limitedireita;
    public float limiteesquerda;
    public bool travaCamera;

    // Start is called before the first frame update
    void Start()
    {
        Playertransform = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        if (!travaCamera)
        {
            if (Playertransform.position.x <= limiteesquerda)
            {
                travaCamera = true;
            }
            else if (Playertransform.position.x >= limitedireita)
            {
                travaCamera = true;
            }
        }
        else if (Playertransform.position.x > limiteesquerda && Playertransform.position.x < limitedireita)
        {
            travaCamera = false;
        }
    }
    private void LateUpdate()
    {
        if (!travaCamera)
        {
            transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}