using UnityEngine;

public class Faca : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float recuo;
    private Rigidbody2D facaBody;
    private Rigidbody2D caboBody;
    [HideInInspector] public bool presa = false;
    [HideInInspector] public bool hit = false;
    private bool repulse = false;

    private void Start()
    {
        facaBody = GetComponent<Rigidbody2D>();
        caboBody = GetComponentInChildren<Rigidbody2D>();
        FindObjectOfType<AcharFaca>().faca = this;
    }

    private void FixedUpdate()
    {
        if(hit == true && repulse == false)
        {
            facaBody.AddForce(Vector2.down * recuo, ForceMode2D.Impulse);
            repulse = true;
        }
            
    }

    public void Jogar()
    {
        facaBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(presa == false)
        {
            if (collision.gameObject.CompareTag("Faca"))
            {
                hit = true;
                Debug.Log(collision.gameObject);

                    //facaBody.AddForce(Vector2.down * recuo, ForceMode2D.Impulse);
                    GetComponentInChildren<BoxCollider2D>().enabled = false;
                    facaBody.constraints = RigidbodyConstraints2D.None;
                    //GetComponent<BoxCollider2D>().enabled = false;
                    GetComponentInChildren<BoxCollider2D>().enabled = false;
                    transform.parent = null;
                if (transform.parent == null)
                {
                }

                foreach (GameOver og in Resources.FindObjectsOfTypeAll<GameOver>())
                {
                    og.gameObject.SetActive(true);
                }
            }
        }
        
    }
}