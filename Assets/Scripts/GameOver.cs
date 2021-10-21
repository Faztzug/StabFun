using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Vidas vidasClass;

    private void Start()
    {
        vidasClass = FindObjectOfType<Vidas>();
        gameObject.SetActive(false);
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }

    private void OnEnable()
    {
        Debug.Log("GameOver Enable");
    }

    public void ChamarGameOver()
    {
        
        if (vidasClass.vidas > 0)
        {
            vidasClass.PerderVida();
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<SFXManager>().gameOver.Play();
            gameObject.SetActive(true);
        }
            
    }
}