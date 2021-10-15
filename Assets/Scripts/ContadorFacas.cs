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
            transform.GetChild(facasAtuais).GetChild(0).gameObject.SetActive(false);
            facasAtuais++;
            scorePoints++;
            scoreText.text = scoreString + scorePoints;
        }
        
        if (facasAtuais > facasTotal - 1)
        {
            Debug.Log("Vitoria");
            Destroy(FindObjectOfType<RodaRodaGiraGira>().gameObject);
            criarCepo.Spawn();

        }
            
    }

    public void GerarFacas()
    {
        

        foreach (Transform faca in GetComponentsInChildren<Transform>())
        {
            faca.GetChild(0).gameObject.SetActive(true);
        }

        facasTotal = transform.childCount;

        facasAtuais = 0;
    }
}
