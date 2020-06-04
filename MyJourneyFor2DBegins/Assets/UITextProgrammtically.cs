using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextProgrammtically : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    Text textComponent;

    void Start()
    {
        textComponent.text = (" This game is gonna show you how to prevent ourselves from CORONA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
