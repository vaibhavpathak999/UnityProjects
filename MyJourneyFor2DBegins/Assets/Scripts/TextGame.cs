using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGame : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text textComponent;
    [SerializeField] State States;
    


    State state; //state is nothing but current state

    void Start()
    {
        state = States;
        textComponent.text = state.GetStateStory();
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    void ManageStates()
    {
        var nextStates = state.GetNextState(); 

        for(int index = 0; index < nextStates.Length; index++ )
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }
        textComponent.text = state.GetStateStory();
    }
}
