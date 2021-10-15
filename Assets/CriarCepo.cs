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

    public void Spawn()
    {
        StartCoroutine(SpawnCepo());
        //if (FindObjectOfType<GameOver>() == null)
            
    }

    public IEnumerator SpawnCepo()
    {
        stopInput.gameObject.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);

        Instantiate(cepoGO);
        stopInput.gameObject.SetActive(false);
    }

}
