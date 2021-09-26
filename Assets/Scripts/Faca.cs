using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faca : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody2D facaBody;
    private Rigidbody2D caboBody;

    private void Start()
    {
        facaBody = GetComponent<Rigidbody2D>();
        caboBody = GetComponentInChildren<Rigidbody2D>();
        FindObjectOfType<AcharFaca>().faca = this;
    }

    public void Jogar()
    {
        facaBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
