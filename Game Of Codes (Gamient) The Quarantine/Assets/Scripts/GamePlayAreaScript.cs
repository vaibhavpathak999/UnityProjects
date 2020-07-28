using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayAreaScript : MonoBehaviour
{
    private GameObject powerUp;
        
    public void GetPower(GameObject powerUpToSelect)
    {
        powerUp = powerUpToSelect;
    }

    private void OnMouseDown()
    {
        Vector2 positionClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SearchForPersonInPlayArea(positionClick); 
    }
    private void SearchForPersonInPlayArea(Vector2 positionOfClick)
    {
        //Debug.Log("Hello");
        var persons =  FindObjectsOfType<RandomMotion>();
        foreach(RandomMotion person in persons)
        {
            //Debug.Log(positionOfClick.ToString() + person.transform.position.ToString());
            if (positionOfClick.x < person.transform.position.x + 3 && positionOfClick.x > transform.position.x -3 &&
                positionOfClick.y < person.transform.position.y + 3 && positionOfClick.y > transform.position.y - 3)
            {
                Debug.Log(positionOfClick.ToString() + person.name + person.transform.position.ToString());
            }
        }
        
    }
}
