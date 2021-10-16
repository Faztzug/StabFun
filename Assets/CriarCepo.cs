using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarCepo : MonoBehaviour
{
    [SerializeField] private GameObject cepoGO;
    [SerializeField] private float waitSeconds = 1;
    private StopInput stopInput;

    private void Start()
    {
        stopInput = FindObjectOfType<StopInput>();
        stopInput.gameObject.SetActive(false);
    }

    public void Spawn(float espera)
    {
        StartCoroutine(SpawnCepo(espera));
        //if (FindObjectOfType<GameOver>() == null)
            
    }

    public IEnumerator SpawnCepo(float espera)
    {
        stopInput.gameObject.SetActive(true);

        yield return new WaitForSeconds(espera);

        Instantiate(cepoGO);
        stopInput.gameObject.SetActive(false);
    }

}
