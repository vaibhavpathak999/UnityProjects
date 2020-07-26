using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D Collider)
    {
        GameObject targetGameObject = Collider.gameObject;
        if(targetGameObject.GetComponent<Defender>())
        {
            if (targetGameObject.name == "GraveStone(Clone)")
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }
            else
            {
                Debug.Log(targetGameObject.name);
                GetComponent<Attacker>().Attack(targetGameObject);
            }    
        }
    }
}
