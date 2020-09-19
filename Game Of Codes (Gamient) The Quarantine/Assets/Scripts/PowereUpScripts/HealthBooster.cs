using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HealthAndImmunity>())
        {
            if (otherCollider.GetComponent<HealthAndImmunity>().isInfected)
            {
                otherCollider.GetComponent<HealthAndImmunity>().SetHealth(50);
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
