using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQuarantine : MonoBehaviour
{
   private void Start()
    {
       StartCoroutine(PersonQuarantined());
    }
    IEnumerator PersonQuarantined()
    {
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
