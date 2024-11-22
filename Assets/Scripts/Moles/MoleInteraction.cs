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
        // Vérifie si l'objet entrant est le marteau
        if (other.gameObject.CompareTag("Hammer")) // Assurez-vous que le marteau a le tag "Hammer"
        {
            Debug.Log("Taupe touchée");
            // Supprime la taupe via le script parent
            StartCoroutine(moleManager.DeleteMole(gameObject));
            moleHitted.OnMoleHit();
            Debug.Log("Taupe supprimée");
            
        }
    }
}
