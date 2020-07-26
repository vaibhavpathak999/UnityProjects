using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject targetObject = otherCollider.gameObject;
        
        if(targetObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(targetObject);
        }        
    }
}
