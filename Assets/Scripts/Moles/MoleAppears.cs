using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MoleAppears : MonoBehaviour
{
    public GameObject[] MolePrefabs;
    public GameObject Holes;
    private bool alreadyMole = false;

    void Start()
    {
        StartCoroutine(RandomMole());
    }

    private IEnumerator RandomMole()
    {
        if (alreadyMole)
        {
            yield break;
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

        // Ajouter le script MoleInteraction pour gérer les collisions (voir ci-dessous)
        if (newMole.GetComponent<MoleInteraction>() == null)
        {
            newMole.AddComponent<MoleInteraction>().SetParent(this);
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DeleteMole(newMole));
    }

    public IEnumerator DeleteMole(GameObject moleInstance)
    {
        if (moleInstance != null)
        {
            Vector3 molePosition = moleInstance.transform.position;
            molePosition.y -= 1;
            moleInstance.transform.DOMove(new Vector3(molePosition.x, molePosition.y, molePosition.z), 1);
            yield return new WaitForSeconds(1f);
            Destroy(moleInstance);
            alreadyMole = false;
            StartCoroutine(RandomMole());
        }
    }
}

