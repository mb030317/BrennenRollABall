using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public float kickback;
    private Rigidbody rb;

    void Start()
    {
        //Set rb to the gun object's rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    public void shoot()
    {
        rb.AddForce(kickback, 0, 0, ForceMode.Impulse);
    }
}
