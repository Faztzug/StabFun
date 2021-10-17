using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacaSlot : MonoBehaviour
{
    private GameObject icon;

    private void Start()
    {
        icon = transform.GetChild(0).gameObject;
        GerarIcone();
    }

    public void GerarIcone()
    {
        icon.SetActive(true);
        //Instantiate(icon, this.transform);
    }

    public void TirarIcone()
    {
        icon.SetActive(false);
    }
}
