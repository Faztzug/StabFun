using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcharFaca : MonoBehaviour
{
    [HideInInspector]
    public Faca faca;
    
    public void ArremessarFaca()
    {
        //Faca faca = FindObjectOfType<Faca>();
        if(faca != null)
        {
            faca.Jogar();
            faca = null;
        }
        
    }

}
