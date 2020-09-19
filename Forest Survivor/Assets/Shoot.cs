using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shootarrow : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;

    public void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawn.position,arrowSpawn.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = cam.transform.forward * shootForce;
    }

}
