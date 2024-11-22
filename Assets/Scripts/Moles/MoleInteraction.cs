using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleInteraction : MonoBehaviour
{
    [SerializeField]
    private MoleAppears moleManager;
    
    private Mole moleHitted;
    private void Start()
    {
        moleHitted = GameObject.Find("Canvas").GetComponent<Mole>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Hammer"))
        {
            Debug.Log("Taupe touchée");
            StartCoroutine(moleManager.DeleteMole(gameObject));
            moleHitted.OnMoleHit();
            Debug.Log("Taupe supprimée");
            
        }
    }
}
