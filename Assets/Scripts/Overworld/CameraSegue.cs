using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Transform Playertransform;
    float limitedireita = 8.36f;
    float limiteesquerda = -8.77f;
    public bool travaCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);

        
    }

    private bool TravaNosLimitesHorizontais(float limiteEsquerda, float limiteDireita)
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
    travaCamera = TravaNosLimitesHorizontais(limiteesquerda,limitedireita);
        if (!travaCamera){
            this.transform.position = new Vector3(Playertransform.position.x, this.transform.position.y, this.transform.position.z);}
    }
}

