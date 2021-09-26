using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarFaca : MonoBehaviour
{
    [SerializeField] GameObject facaGO;
    public void Spawn()
    {
        if(FindObjectOfType<GameOver>() == null)
        Instantiate(facaGO);
    }
}
