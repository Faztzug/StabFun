using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacaSlot : MonoBehaviour
{
    [SerializeField] private GameObject icon;

    private void Start()
    {
        Instantiate(icon, this.transform);
    }
}
