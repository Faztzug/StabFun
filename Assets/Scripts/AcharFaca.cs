using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcharFaca : MonoBehaviour
{
    [HideInInspector]
    public Faca faca;
    private SFXManager sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }


    public void ArremessarFaca()
    {
        //Faca faca = FindObjectOfType<Faca>();
        if(faca != null)
        {
            sfx.jogarFaca.Play();
            faca.Jogar();
            faca = null;
        }
        
    }

}
