using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeLoadEffect : MonoBehaviour
{
    
    
    
    private Animator crossfadeTransition;
    [SerializeField] private float tempoDeCrossfade = 1f;

    private void Start()
    {
        crossfadeTransition = GetComponent<Animator>();
    }

    public void ChamarCrossfade(string cena, Vector2 novaPosicao)
    {
        StartCoroutine(IniciarCrossfade(cena, novaPosicao));
    }

    IEnumerator IniciarCrossfade(string cena, Vector2 novaPosicao)
    {
        crossfadeTransition.SetTrigger("Start");
        yield return new WaitForSeconds(tempoDeCrossfade);

        SceneManager.LoadScene(cena);

        

        crossfadeTransition.SetTrigger("End");
    }
}
