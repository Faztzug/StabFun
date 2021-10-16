using UnityEngine;

public class RodaRodaGiraGira : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private float maxSpeed = 270;
    [SerializeField] private float accelaration = 15;

    private Rigidbody2D rgbd2d;
    private Transform cepo;
    private CriarFaca criarFaca;
    private ContadorFacas contadorFacas;

    private void Start()
    {
        //rgbd2d = GetComponent<Rigidbody2D>();
        cepo = this.transform;
        criarFaca = FindObjectOfType<CriarFaca>();
        contadorFacas = FindObjectOfType<ContadorFacas>();
        //rgbd2d = FindObjectOfType<Rigidbody2D>();
    }

    private void Update()
    {
        if(speed < maxSpeed)
        {
            speed += accelaration * Time.deltaTime;
            
        } else if(speed > maxSpeed)
        {
            speed -= accelaration * Time.deltaTime;
        }

        cepo.Rotate(0, 0, speed * Time.deltaTime, Space.Self);

    }

    private void FixedUpdate()
    {
        //rgbd2d.AddTorque(speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Faca"))
        {
            if (collision.gameObject.GetComponentInParent<Faca>().hit == false)
            {
                
                collision.gameObject.transform.SetParent(this.gameObject.transform);
                collision.rigidbody.velocity = Vector2.zero;
                collision.rigidbody.angularVelocity = 0;
                collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                //collision.rigidbody.mass = collision.rigidbody.mass * 10;
                collision.gameObject.GetComponentInParent<Faca>().presa = true;
                collision.gameObject.GetComponentInParent<Faca>().enabled = false;
                contadorFacas.MenosUma();
                criarFaca.Spawn();
            }
        }
    }
}