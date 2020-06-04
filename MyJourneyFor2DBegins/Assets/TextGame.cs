using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGame : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state; //state is nothing but current state

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
            ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
