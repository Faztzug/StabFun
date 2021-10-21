using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject frutaP;
    [SerializeField] float frutaPYCorrection;

    [SerializeField]
    private GameObject facaP;
    [SerializeField] float facaPYCorrection;

    public void frutaParticle(Vector2 position, Quaternion rotation)
    {
        //Destroy(frutaP, 3f);
        frutaP.transform.position = new Vector2(position.x,position.y + frutaPYCorrection);
        frutaP.transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z + 180, rotation.w);
            //Quaternion.Euler(rotation.x, rotation.y, rotation.z + 180);
        Instantiate(frutaP);
        
    }

    public void facaParticle(Transform parent)
    {
        
        //facaP.transform.position = new Vector2(position.x, position.y + facaPYCorrection);
        //facaP.transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z + 180, rotation.w);

        
        
        Instantiate(facaP, 
            new Vector2(parent.transform.position.x, parent.transform.position.y + facaPYCorrection), 
            Quaternion.Euler(parent.transform.rotation.x, parent.transform.rotation.y, 
            parent.transform.rotation.z + 180), parent);

    }
}
