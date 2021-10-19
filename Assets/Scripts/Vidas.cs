using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public int vidas = 1;
    public string dummyText;
    public Text vidasText;
    private CriarFaca criarFaca;
    [SerializeField] private float esperarSpawn = 1f;

    void Start()
    {
        vidasText = GetComponentInChildren<Text>();
        dummyText = vidasText.text;
        vidasText.text = dummyText + vidas;
        criarFaca = FindObjectOfType<CriarFaca>();
    }

    public void PerderVida()
    {
        vidas--;
        vidasText.text = dummyText + vidas;
        Debug.Log("Perdeu uma vida!");
        StartCoroutine(EsperarSpawn());
        
    }

    public void GanharVida()
    {
        vidas++;
        vidasText.text = dummyText + vidas;
        Debug.Log("Ganhou uma vida!");
    }

    IEnumerator EsperarSpawn()
    {
        yield return new WaitForSeconds(esperarSpawn);
        criarFaca.Spawn();
    }

}
