using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoleAppears : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public GameObject[] MolePrefabs;
    public GameObject Holes;
    private bool alreadyMole = false;
    private bool stopSpawning = false; // Variable de contrôle pour arrêter les coroutines

    public IEnumerator RandomMole()
    {
        while (gameData.getLives() > 0 && !stopSpawning)
        {
            if (alreadyMole)
            {
                yield return null;
                continue;
            }

            alreadyMole = true;

            int moleIndex = Random.Range(0, MolePrefabs.Length);
            int holeIndex = Random.Range(1, 12);
            GameObject Mole = MolePrefabs[moleIndex];
            string HoleName = "Hole" + holeIndex;
            GameObject Hole = GameObject.Find(HoleName);

            Vector3 holePosition = Hole.transform.position;
            holePosition.y -= 1;

            GameObject newMole = Instantiate(Mole, holePosition, Hole.transform.rotation);
            holePosition.y += 1;
            newMole.transform.DOMove(new Vector3(holePosition.x, holePosition.y, holePosition.z), 1);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(DeleteMole(newMole));
            if (gameData.getLives() == 0)
            {
                stopSpawning = true; 
            }
        }
    }

    // À appeler lorsqu'une taupe est touchée par le marteau
    private IEnumerator DeleteMole(GameObject moleInstance)
    {
        if (moleInstance != null)
        {
            Vector3 molePosition = moleInstance.transform.position;
            molePosition.y -= 1;
            moleInstance.transform.DOMove(new Vector3(molePosition.x, molePosition.y, molePosition.z), 1);
            yield return new WaitForSeconds(1f);
            Destroy(moleInstance);
            alreadyMole = false;
        }
    }

    // Méthode pour arrêter toutes les coroutines en cas de game over ou autre
    public void StopAllCoroutinesAndSpawning()
    {
        stopSpawning = true;
        StopAllCoroutines();
    }
}
