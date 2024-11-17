using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHammer : MonoBehaviour
{
    [SerializeField] private GameObject NewHammer;

    private bool isColliding = false;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider Hammer)
    {
        if (isColliding) return;
        isColliding = true;
        Destroy(Hammer.gameObject.transform.parent.gameObject) ; 
        Instantiate(NewHammer, new Vector3(0f, 1f, 0f), Quaternion.identity);
        StartCoroutine(Reset());

        

    }

   IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        isColliding = false;
    }
}
