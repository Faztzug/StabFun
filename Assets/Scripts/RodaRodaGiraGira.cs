using System.Collections;
using UnityEngine;

public class RodaRodaGiraGira : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private float maxSpeed = 270;
    [SerializeField] private float accelaration = 15;
    [SerializeField] private float increaseAccelaration = 0.5f;
    [SerializeField] private float maxAccelaration = 50;
    [SerializeField] private float timeToChange = 1f;
    [SerializeField] private float sentido;

    [SerializeField] private Vector2 speedRange = new Vector2(-100, 100);
    [SerializeField] private Vector2 maxSpeedRange = new Vector2(0, 500);
    [SerializeField] private Vector2 accelarationRange = new Vector2(1, 50);
    [SerializeField] private Vector2 increaseAccelarationRange = new Vector2(0, 1);
    [SerializeField] private Vector2 maxAccelarationRange = new Vector2(10, 50);
    [SerializeField] private Vector2 timeToChangeRange = new Vector2(0.3f, 1.3f);

    private Rigidbody2D rgbd2d;
    private Transform cepo;
    private CriarFaca criarFaca;
    private ContadorFacas contadorFacas;

    [SerializeField] private GameObject fruta;
    [SerializeField] private float frutaSpawnChance;
    [SerializeField] private GameObject faca;
    [SerializeField] private float facaSpawnChance;
    [SerializeField] private int spawnSections = 12;
    private float grausSpawn;
    //private float grauAtual = 0;
    [SerializeField] private Vector2 frutaSpawnPosition;
    [SerializeField] private Vector2 facaSpawnPosition;

    //private AudioSource SFXfacaNaMadeira;
    [HideInInspector]
    public SFXManager sfx;
    

    private void Start()
    {
        //rgbd2d = GetComponent<Rigidbody2D>();
        cepo = this.transform;
        criarFaca = FindObjectOfType<CriarFaca>();
        contadorFacas = FindObjectOfType<ContadorFacas>();
        //rgbd2d = FindObjectOfType<Rigidbody2D>();

        RandomizeStats(true);
        StartCoroutine(CourotineRandomizeAgain());

        grausSpawn = 360 / spawnSections;
        SpawnObjects();
        //StartCoroutine(SpawnTeste());

        /*foreach (DummyFaca dFaca in GetComponentsInChildren<DummyFaca>())
        {
            dFaca.Jogar();
        }*/

        //SFXfacaNaMadeira = GetComponent<AudioSource>();
        sfx = FindObjectOfType<SFXManager>();
    }

    private void SpawnObjects()
    {
        int childsNumber;
        float rng;

        for (int i = 0; i < spawnSections; i++)
        {
            rng = Random.Range(1f, 100f);
            transform.rotation = Quaternion.Euler(0, 0, grausSpawn * i);
            childsNumber = transform.childCount;

            if (frutaSpawnChance >= rng)
            {
                Instantiate(fruta, this.transform);
                transform.GetChild(childsNumber).position = new Vector2(0, 0 + frutaSpawnPosition.y);
                //transform.GetChild(i).Translate(frutaSpawnPosition);
                transform.GetChild(childsNumber).rotation = Quaternion.Euler(0, 0, 180);
                //transform.GetChild(i).
                //RotateAround(transform.GetChild(i).position, this.transform.position, grauAtual);
            }
            else
            {
                rng = Random.Range(1f, 100f);
                if (facaSpawnChance >= rng)
                {
                    Instantiate(faca, this.transform);
                    transform.GetChild(childsNumber).position = new Vector2(0, 0 + facaSpawnPosition.y);
                    //transform.GetChild(i).Translate(frutaSpawnPosition);
                    transform.GetChild(childsNumber).rotation = Quaternion.Euler(0, 0, 180);
                    //transform.GetChild(i).GetComponent<Faca>().facaBox.enabled = false;
                    contadorFacas.MenosFacas(1);
                }
            }

            //cepo.Rotate(0, 0, grausSpawn);

            //grauAtual += grausSpawn;
        }
    }

    private void Update()
    {
        Rotation();
    }

    public void RandomizeStats(bool noStart)
    {
        sentido = Random.Range(-1f, 1f);

        if (noStart == true)
            speed =
                Random.Range(speedRange.x, speedRange.y);

        maxSpeed =
            Random.Range(maxSpeedRange.x, maxSpeedRange.y);
        accelaration =
            Random.Range(accelarationRange.x, accelarationRange.y);
        maxAccelaration =
            Random.Range(maxAccelarationRange.x, maxAccelarationRange.y);
        increaseAccelaration =
            Random.Range(increaseAccelarationRange.x, increaseAccelarationRange.y);
        timeToChange =
            Random.Range(timeToChangeRange.x, timeToChangeRange.y);

        if (sentido <= 0)
            maxSpeed = maxSpeed * -1;
    }

    public IEnumerator CourotineRandomizeAgain()
    {
        yield return new WaitForSeconds(timeToChange);

        RandomizeStats(false);

        StartCoroutine(CourotineRandomizeAgain());
    }

    public void Rotation()
    {
        if (speed < maxSpeed)
        {
            speed += accelaration * Time.deltaTime;

            if (speed < maxSpeed - 1 && accelaration < maxAccelaration)
            {
                accelaration += (accelaration * increaseAccelaration) * Time.deltaTime;
            }
        }
        else if (speed > maxSpeed)
        {
            speed -= accelaration * Time.deltaTime;

            if (speed > maxSpeed + 1 && accelaration < maxAccelaration)
            {
                accelaration += (accelaration * increaseAccelaration) * Time.deltaTime;
            }
        }

        if (accelaration > maxAccelaration)
            accelaration = maxAccelaration;

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
            if (collision.gameObject.GetComponentInParent<Faca>().hit == false
                && collision.gameObject.GetComponentInParent<Faca>().dummyFaca == false)
            {
                //SFXfacaNaMadeira.Play();
                sfx.facaNaMadeira.Play();
                
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

    public void DestruirCepo()
    {
        foreach (Faca faca in GetComponentsInChildren<Faca>())
        {
            faca.LibertarEDestruir();
        }

        /*int childLenght = transform.childCount;
        for (int i = 0; i <= childLenght; i++)
        {
            transform.GetChild(i).gameObject.transform.parent = null;
        }*/

        Destroy(this.gameObject);
    }
}