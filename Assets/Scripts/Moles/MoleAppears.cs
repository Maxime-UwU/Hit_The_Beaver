using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleAppears : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        RandomMole();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomMole()
    {
        GameObject Mole;
        int moleNumber = Random.Range(0, 20);
        string moleName;
        if (moleNumber == 0)
        {
            moleName = "Mole";
            Mole = GameObject.Find(moleName);
        }
        else
        {
            string moleNumberFormatted = moleNumber.ToString("D2");
            moleName = "Mole.0" + moleNumberFormatted;
            Mole = GameObject.Find(moleName);
        }
        Debug.Log(moleNumber);
        GameObject.Instantiate(Mole);
        StartCoroutine(DeleteMole(moleName));

        //Mole.transform.position = new Vector3(Mole.transform.position.x + 10, 10, 10);
    }

    private IEnumerator DeleteMole(string mole)
    {
        yield return new WaitForSeconds(5f);
        Debug.Log(mole);
        GameObject LastMole = GameObject.Find(mole + "(Clone)");
        Destroy(LastMole);
    }
}
