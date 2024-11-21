using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleInteraction : MonoBehaviour
{
    private MoleAppears moleManager;

    // Permet de connecter ce script au script MoleAppears
    public void SetParent(MoleAppears manager)
    {
        moleManager = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est le marteau
        if (other.gameObject.CompareTag("Hammer")) // Assurez-vous que le marteau a le tag "Hammer"
        {
            // Supprime la taupe via le script parent
            if (moleManager != null)
            {
                StartCoroutine(moleManager.DeleteMole(gameObject));
            }
        }
    }
}
