using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private ContadorFacas contadorFacas;
    
    void Start()
    {
        contadorFacas = FindObjectOfType<ContadorFacas>();
        //transform.parent = FindObjectOfType<RodaRodaGiraGira>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Faca"))
        {
            transform.parent.GetComponent<RodaRodaGiraGira>().sfx.cortarFruta.Play();
            contadorFacas.GanharPontos(2);
            Destroy(this.gameObject);

        }
    }

    
}
