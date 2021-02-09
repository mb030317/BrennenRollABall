using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public float kickback;
    private Rigidbody rb;
    public Rigidbody playerRB;

    void Start()
    {
        //Set rb to the gun object's rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        playerRB = transform.parent.gameObject.GetComponent<Rigidbody>(); //Gets the player rb to add kickback force
    }

    //function that runs when right trigger is pressed, referenced in PlayerController.cs
    public void shoot()
    {

    }
}
