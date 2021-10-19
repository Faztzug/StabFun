using UnityEngine;

public class Faca : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float recuo;
    [HideInInspector] public Rigidbody2D facaBody;
    private Rigidbody2D caboBody;
    [HideInInspector] public bool presa = false;
    [HideInInspector] public bool hit = false;
    private bool repulse = false;

    [HideInInspector]
    public BoxCollider2D facaBox;

    [HideInInspector]
    public BoxCollider2D caboBox;

    [SerializeField] private Vector2 destruirAposRange = new Vector2(3f, 8f);
    [SerializeField] private Vector2 destruirTorqueRange = new Vector2(-1f, 1f);
    [SerializeField] private float destruirApos;
    [SerializeField] private float destruirTorque;

    private void Start()
    {
        facaBody = GetComponent<Rigidbody2D>();
        caboBody = GetComponentInChildren<Rigidbody2D>();
        FindObjectOfType<AcharFaca>().faca = this;
        facaBox = GetComponent<BoxCollider2D>();
        caboBox = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();

        destruirApos = Random.Range(destruirAposRange.x, destruirAposRange.y);
        destruirTorque = Random.Range(destruirTorqueRange.x, destruirTorqueRange.y);
    }

    private void FixedUpdate()
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

    public void LibertarEDestruir()
    {
        transform.parent = null;
        facaBox.enabled = false;
        caboBox.enabled = false;
        facaBody.constraints = RigidbodyConstraints2D.None;
        facaBody.gravityScale = 1;
        facaBody.AddTorque(destruirTorque);
        Destroy(this.gameObject, destruirApos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (presa == false)
        {
            if (collision.gameObject.CompareTag("Faca"))
            {
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

                foreach (GameOver go in Resources.FindObjectsOfTypeAll<GameOver>())
                {
                    go.ChamarGameOver();
                }
            }
        }
    }
}