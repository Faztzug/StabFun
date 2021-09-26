using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faca : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float recuo;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Faca"))
        {
            Debug.Log(collision.gameObject);

            
            if(transform.parent != null)
            {
                GetComponentInChildren<BoxCollider2D>().enabled = false;
                facaBody.constraints = RigidbodyConstraints2D.None;
                facaBody.AddForce(Vector2.down * recuo, ForceMode2D.Impulse);
                transform.parent = null;
                
            }
            

            foreach (GameOver og in Resources.FindObjectsOfTypeAll<GameOver>())
            {
                og.gameObject.SetActive(true);
            }
            
        }
    }
}
