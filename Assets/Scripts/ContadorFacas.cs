using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorFacas : MonoBehaviour
{
    [SerializeField]
    private int facasTotal;
    private int facasAtuais;
    private int scorePoints;
    private string scoreString;
    private Text scoreText;
    private CriarCepo criarCepo;

    private void Start()
    {
        facasTotal = transform.childCount;
        facasAtuais = 0;
        scorePoints = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreString = scoreText.text;
        scoreText.text = scoreString + scorePoints;

        criarCepo = FindObjectOfType<CriarCepo>();
    }
    public void MenosUma()
    {
        if(facasAtuais < facasTotal)
        {
            Destroy(transform.GetChild(facasAtuais).GetChild(0).gameObject);
            //transform.GetChild(facasAtuais).GetChild(0).gameObject.SetActive(false);
            facasAtuais++;
            scorePoints++;
            scoreText.text = scoreString + scorePoints;
        }
        
        if (facasAtuais > facasTotal - 1)
        {
            Debug.Log("Vitoria");
            Destroy(FindObjectOfType<RodaRodaGiraGira>().gameObject);
            criarCepo.Spawn();
            GerarFacas();
        }
            
    }

    public void GerarFacas()
    {
        

        foreach (FacaSlot faca in FindObjectsOfType<FacaSlot>())
        {
            faca.GerarIcone();
        }

        facasTotal = transform.childCount;

        facasAtuais = 0;
    }
}
