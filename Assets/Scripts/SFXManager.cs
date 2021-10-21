using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip clipFacaNaMadeira;
    [SerializeField] private AudioClip clipGameOver;
    [SerializeField] private AudioClip clipFacaNaFaca;
    [SerializeField] private AudioClip clipGanharVida;
    [SerializeField] private AudioClip clipCortarFruta;
    [SerializeField] private AudioClip clipJogarFaca;

    [HideInInspector] public AudioSource facaNaMadeira;
    [HideInInspector] public AudioSource gameOver;
    [HideInInspector] public AudioSource facaNaFaca;
    [HideInInspector] public AudioSource ganharVida;
    [HideInInspector] public AudioSource cortarFruta;
    [HideInInspector] public AudioSource jogarFaca;

    private void Start()
    {

        facaNaMadeira = gameObject.AddComponent<AudioSource>();
        facaNaMadeira.clip = clipFacaNaMadeira;
        gameOver = gameObject.AddComponent<AudioSource>();
        gameOver.clip = clipGameOver;
        facaNaFaca = gameObject.AddComponent<AudioSource>();
        facaNaFaca.clip = clipFacaNaFaca;
        ganharVida = gameObject.AddComponent<AudioSource>();
        ganharVida.clip = clipGanharVida;
        cortarFruta = gameObject.AddComponent<AudioSource>();
        cortarFruta.clip = clipCortarFruta;
        jogarFaca = gameObject.AddComponent<AudioSource>();
        jogarFaca.clip = clipJogarFaca;


    }

}
