using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacaSlot : MonoBehaviour
{
    [SerializeField] private GameObject icon;

    private void Start()
    {
        GerarIcone();
    }

    public void GerarIcone()
    {
        Instantiate(icon, this.transform);
    }
}
