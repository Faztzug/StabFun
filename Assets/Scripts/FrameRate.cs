using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField] [Range(30,60)] int FPS = 30;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = FPS;
    }

    
}
