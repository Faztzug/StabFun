using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorFacas : MonoBehaviour
{
    [SerializeField]
    private int facasTotal;
    private int facasAtuais;

    private void Start()
    {
        facasTotal = transform.childCount;
        facasAtuais = 0;
    }
    public void MenosUma()
    {
        if(facasAtuais < facasTotal)
        {
            transform.GetChild(facasAtuais).GetChild(0).gameObject.SetActive(false);
            facasAtuais++;
        }
        
        if (facasAtuais >= facasTotal - 1)
            Debug.Log("Vitoria");
    }
}
