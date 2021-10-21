using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private ContadorFacas contadorFacas;
    private CircleCollider2D frutaCollider;
    private Rigidbody2D rgbd;

    [SerializeField] private Vector2 destruirAposRange = new Vector2(3f, 8f);
    [SerializeField] private Vector2 destruirTorqueRange = new Vector2(-8f, 8f);
    private float destruirApos;
    private float destruirTorque;
    [SerializeField] protected Vector2 destruirForceRange = new Vector2(-6f, 6f);
    [SerializeField] protected float destruirForceX;
    [SerializeField] protected float destruirForceY;

    void Start()
    {
        contadorFacas = FindObjectOfType<ContadorFacas>();
        //transform.parent = FindObjectOfType<RodaRodaGiraGira>().transform;
        frutaCollider = GetComponent<CircleCollider2D>();
        rgbd = GetComponent<Rigidbody2D>();
        destruirApos = Random.Range(destruirAposRange.x, destruirAposRange.y);
        destruirTorque = Random.Range(destruirTorqueRange.x, destruirTorqueRange.y);
        destruirForceX = Random.Range(destruirForceRange.x, destruirForceRange.y);
        destruirForceY = Random.Range(0, destruirForceRange.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Faca"))
        {
            contadorFacas.particleSpawner.frutaParticle(transform.position, transform.rotation);
            transform.parent.GetComponent<RodaRodaGiraGira>().sfx.cortarFruta.Play();
            contadorFacas.GanharPontos(2);
            Destroy(this.gameObject);

        }
    }

    public void LibertarEDestruir()
    {
        transform.parent = null;
        frutaCollider.enabled = false;
        
        rgbd.constraints = RigidbodyConstraints2D.None;
        rgbd.gravityScale = 1;
        rgbd.AddTorque(destruirTorque);
        rgbd.AddForce(new Vector2(destruirForceX, destruirForceY), ForceMode2D.Impulse);
        Destroy(this.gameObject, destruirApos);
    }


}
