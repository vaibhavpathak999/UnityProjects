using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButton : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;

    private void OnMouseDown()
    {
        Vector3 positionOfClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newPower = Instantiate(powerUpPrefab, positionOfClick, Quaternion.identity);
    }

}
