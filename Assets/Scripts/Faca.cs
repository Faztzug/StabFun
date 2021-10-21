using UnityEngine;
using System.Collections;

public class Faca : MonoBehaviour
{
    [SerializeField] protected float force;
    [SerializeField] protected float recuo;
    [HideInInspector] public Rigidbody2D facaBody;
    protected Rigidbody2D caboBody;
    [HideInInspector] public bool presa = false;
    [HideInInspector] public bool hit = false;
    protected bool repulse = false;

    [HideInInspector]
    public BoxCollider2D facaBox;

    [HideInInspector]
    public BoxCollider2D caboBox;

    [SerializeField] protected Vector2 destruirAposRange = new Vector2(3f, 8f);
    [SerializeField] protected Vector2 destruirTorqueRange = new Vector2(-1f, 1f);
    [SerializeField] protected float destruirApos;
    [SerializeField] protected float destruirTorque;
    [SerializeField] protected Vector2 destruirForceRange = new Vector2(-6f, 6f);
    [SerializeField] protected float destruirForceX;
    [SerializeField] protected float destruirForceY;

    [HideInInspector] public bool dummyFaca = false;

    protected void Start()
    {
        facaBody = GetComponent<Rigidbody2D>();
        caboBody = GetComponentInChildren<Rigidbody2D>();
        //
        StartCoroutine(AcharFaca());

        facaBox = GetComponent<BoxCollider2D>();
        caboBox = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();

        destruirApos = Random.Range(destruirAposRange.x, destruirAposRange.y);
        destruirTorque = Random.Range(destruirTorqueRange.x, destruirTorqueRange.y);
        destruirForceX = Random.Range(destruirForceRange.x, destruirForceRange.y);
        destruirForceY = Random.Range(0, destruirForceRange.y);

        if (dummyFaca == true)
        {
            //facaBox.enabled = false;
            if (transform.parent != null)
            {
            }

            facaBody.velocity = Vector2.zero;
            facaBody.angularVelocity = 0;
            facaBody.constraints = RigidbodyConstraints2D.FreezeAll;
            //collision.rigidbody.mass = collision.rigidbody.mass * 10;
            presa = true;
            enabled = false;
        }
    }

    protected void FixedUpdate()
    {
        if (hit == true && repulse == false)
        {
            facaBody.AddForce(Vector2.down * recuo, ForceMode2D.Impulse);
            repulse = true;
        }
    }

    public void Jogar()
    {
        facaBody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public IEnumerator AcharFaca()
    {
        yield return new WaitForEndOfFrame();

        if (dummyFaca == false) 
            FindObjectOfType<AcharFaca>().faca = this;

    }

    public void LibertarEDestruir()
    {
        transform.parent = null;
        facaBox.enabled = false;
        caboBox.enabled = false;
        facaBody.constraints = RigidbodyConstraints2D.None;
        facaBody.gravityScale = 1;
        facaBody.AddTorque(destruirTorque);
        facaBody.AddForce(new Vector2(destruirForceX, destruirForceY), ForceMode2D.Impulse);
        Destroy(this.gameObject, destruirApos);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Faca"))
        {
            

        }*/
        //checagem se é a faca arremessada ao inves da presa
        if (presa == false && dummyFaca == false)
        {
            if (collision.gameObject.CompareTag("Faca"))
            {
                FindObjectOfType<SFXManager>().facaNaFaca.Play();
                FindObjectOfType<ParticleSpawner>().facaFacaParticle(this.transform);
                hit = true;
                Debug.Log(collision.gameObject);

                //facaBody.AddForce(Vector2.down * recuo, ForceMode2D.Impulse);
                //GetComponentInChildren<BoxCollider2D>().enabled = false;
                caboBox.enabled = false;

                facaBody.constraints = RigidbodyConstraints2D.None;

                //GetComponent<BoxCollider2D>().enabled = false;
                //GetComponentInChildren<BoxCollider2D>().enabled = false;
                facaBox.enabled = false;

                transform.parent = null;
                if (transform.parent == null)
                {
                }

                Destroy(this.gameObject, 5f);

                foreach (GameOver go in Resources.FindObjectsOfTypeAll<GameOver>())
                {
                    Debug.Log(gameObject.name + " Chamou GameOver");
                    go.ChamarGameOver();
                }
            }
        }
    }
}