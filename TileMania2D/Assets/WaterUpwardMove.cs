using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUpwardMove : MonoBehaviour
{
    [SerializeField] float scrollRate = 0.1f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, Time.deltaTime * scrollRate, 0f);  
    }
}
