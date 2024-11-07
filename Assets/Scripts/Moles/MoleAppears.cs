using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleAppears : MonoBehaviour
{
    GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Mole;
        int moleNumber = Random.Range(0, 20);
        if (moleNumber == 0)
        {
            Mole = GameObject.Find("Mole");
        } else
        {
            string moleNumberFormatted = moleNumber.ToString("D2");
            Mole = GameObject.Find("Mole.0" + moleNumberFormatted);
        }
        Debug.Log(moleNumber);
        Mole.transform.position = new Vector3(Mole.transform.position.x + 10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomMole()
    {

    }
}
