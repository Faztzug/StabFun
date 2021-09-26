using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaRodaGiraGira : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rgbd2d;
    private Transform cepo;

    private void Start()
    {
        //rgbd2d = GetComponent<Rigidbody2D>();
        cepo = this.transform;
    }

    private void Update()
    {
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
            collision.gameObject.transform.SetParent(this.gameObject.transform);
            collision.rigidbody.velocity = Vector2.zero;
            collision.rigidbody.angularVelocity = 0;
            collision.gameObject.GetComponentInParent<Faca>().enabled = false;
            
        }
    }

}
