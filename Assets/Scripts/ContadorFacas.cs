using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorFacas : MonoBehaviour
{
    
    private int facasTotal;
    private int facasAtuais;

    private int scorePoints;
    private string scoreString;
    private Text scoreText;

    private int stagePoints;
    private string stageString;
    private Text stageText;

    private CriarCepo criarCepo;

    [SerializeField] private float esperarSegundosAposVitoria = 1;

    private FacaSlot[] facas;
    [SerializeField] private Vector2Int removerFacasRange = new Vector2Int(0, 4);

    [SerializeField] private int pontosParaGanharVida = 100;
    [SerializeField] private int acresentarPontosParaProximaVida = 100;
    private Vidas vidasClass;

    private SFXManager sfx;

    private void Start()
    {
        facasTotal = transform.childCount;
        facasAtuais = 0;
        scorePoints = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreString = scoreText.text;
        scoreText.text = scoreString + scorePoints;

        stagePoints = 0;
        stageText = GameObject.FindGameObjectWithTag("Stage").GetComponent<Text>();
        stageString = stageText.text;
        stageText.text = stageString + stagePoints;

        criarCepo = FindObjectOfType<CriarCepo>();

        facas = transform.GetComponentsInChildren<FacaSlot>();

        MenosFacas(Random.Range(removerFacasRange.x, removerFacasRange.y));

        vidasClass = FindObjectOfType<Vidas>();

        sfx = FindObjectOfType<SFXManager>();
    }
    public void MenosUma()
    {
        if(facasAtuais < facasTotal)
        {
            //Destroy(transform.GetChild(facasAtuais).GetChild(0).gameObject);

            transform.GetChild(facasAtuais).GetComponent<FacaSlot>().TirarIcone();
            //transform.GetChild(facasAtuais).GetChild(0).gameObject.SetActive(false);

            facasAtuais++;
            GanharPontos(1);
            

            GanharVida();
        }
        
        if (facasAtuais > facasTotal - 1)
        {
            Debug.Log("Vitoria");
            stagePoints++;
            stageText.text = stageString + stagePoints;
            scorePoints += stagePoints;
            scoreText.text = scoreString + scorePoints;

            GanharVida();

            //Destroy(FindObjectOfType<RodaRodaGiraGira>().gameObject);
            FindObjectOfType<RodaRodaGiraGira>().DestruirCepo();
            

            foreach (FacaSlot faca in facas)
            {
                faca.gameObject.SetActive(false);
            }

            StartCoroutine(GerarFacas());

            

        }
            
    }

    public IEnumerator GerarFacas()
    {
        criarCepo.Spawn(esperarSegundosAposVitoria);

        yield return new WaitForSeconds(esperarSegundosAposVitoria);

        foreach (FacaSlot faca in facas)
        {
            faca.gameObject.SetActive(true);
            faca.GerarIcone();
        }

        facasTotal = transform.childCount;

        facasAtuais = 0;

        MenosFacas(Random.Range(removerFacasRange.x, removerFacasRange.y));
    }

    public void GanharPontos(int pontos)
    {
        scorePoints += pontos;
        scoreText.text = scoreString + scorePoints;
    }

    private void GanharVida()
    {
        if(scorePoints >= pontosParaGanharVida)
        {
            sfx.ganharVida.Play();
            pontosParaGanharVida += acresentarPontosParaProximaVida + pontosParaGanharVida;
            vidasClass.GanharVida();
        }
    }

    public void MenosFacas(int quantidade)
    {
        if(facasAtuais < facasTotal)
        {
            for (int i = 0; i < quantidade; i++)
            {
                facas[facasAtuais].gameObject.SetActive(false);
                //facasTotal--;
                facasAtuais++;

            }

            Debug.Log("Quantidade de Facas Removidas: " + quantidade);
        }
        
    }
}
