using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TheLockdown : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    bool mouseIsReleased = false;


    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mouseOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mouseZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mouseOffset;
    }

    private void OnMouseUp()
    {
        mouseIsReleased = true;
        GetComponent<Collider2D>().enabled = true;
    }
private void Start()
    {
        StartCoroutine(LetPlayerPlace());
        FindObjectOfType<RandomMotion>().LockdownEffect();
        IEnumerator LetPlayerPlace()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}
        
    



